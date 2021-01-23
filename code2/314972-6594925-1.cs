    	using System;
	using System.Diagnostics;
	using System.Reflection;
	using System.ServiceProcess;
	using System.Threading;
	using System.Xml;
	using System.Xml.Serialization;
	using DataMigration.Configuration;
	using DataMigration.ObjectModel;
	namespace DataSyncService
	{
		public partial class DataSyncService : ServiceBase
		{
			#region Private Members
			private System.Timers.Timer _timer = null;
			private SimpleScheduleManager.ScheduleDefinition _definition = null;
			private DataMigrationManager _manager = new DataMigrationManager();
			#endregion
			#region Constructor(s)
			public DataSyncService()
			{
				AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolver.Resolve);
				InitializeComponent();
			}
			~DataSyncService()
			{
				_manager = null;
				_definition = null;
				_timer = null;
			}
			#endregion
			#region Public Method(s)
			protected override void OnStart(string[] args)
			{
				Assembly assembly = Assembly.GetExecutingAssembly();
				_manager.ProcessMonitor.Logger.Debug("Assembly Version: ", assembly.GetName().FullName);
				assembly = null;
				SetScheduleFromConfigurationFile();
				_timer = new System.Timers.Timer(1000);
				_timer.AutoReset = true;
				_timer.Enabled = true;
				_timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_ZeroingProcess);
				_timer.Start();
			}
			protected override void OnStop()
			{
				_timer.Stop();
				_timer.Enabled = false;
				_timer = null;
				// block if the Process is active!
				if (_manager.State == DataMigrationState.Processing)
				{
					// I invented my own CancellableAsyncResult (back in the day), now you can use CancellationTokenSource
					CancellableAsyncResult result = _manager.RequestCancel() as CancellableAsyncResult;
					while (!result.IsCompleted) { Thread.Sleep(ServiceConstants.ThreadSleepCount); }
					try
					{
						result.EndInvoke();
					}
					catch (Exception ex)
					{
						ProcessMonitorMessage message = ProcessMonitorMessage.GetErrorOccurredInstance();
						message.EventType = ProcessMonitorEventType.ProcessAlert;
						message.Severity = ProcessMessageSeverity.ErrorStop;
						message.SubjectLine = "Error while stopping service. ";
						message.EventDescription = ex.Message;
						_manager.ProcessMonitor.ReportError(message);
					}
				}
			}
			#endregion
			#region Private Method(s)
			private bool MigrationIsScheduledToRunNow()
			{
				DateTime now = DateTime.Now;
				foreach (string dowString in _definition.ExcludedWeekDays)
				{
					if (now.DayOfWeek.ToString().Equals(dowString))
					{
						Trace.WriteLine("Today is " + dowString, "Excluded by Schedule definition");
						return false;
					}
				}
				foreach (string datePart in _definition.ExcludedDates)
				{
					string dateString = datePart + "/2008"; // 2008 is a leap year so it "allows" all 366 possible dates.
					DateTime excludedDate = Convert.ToDateTime(dateString);
					if (excludedDate.Day.Equals(now.Day) && excludedDate.Month.Equals(now.Month))
					{
						Trace.WriteLine("Today is " + datePart, "Excluded by Schedule definition");
						return false;
					}
				}
				foreach (DateTime runTime in _definition.DailyRunTimes)
				{
					if (runTime.Hour.Equals(now.Hour) && runTime.Minute.Equals(now.Minute))
					{
						Trace.WriteLine("Confirmed Scheduled RunTime: " + runTime.TimeOfDay.ToString(), "Included by Schedule definition");
						return true;
					}
				}
				return false;
			}
			/// <summary>
			/// Load Scheduling Configuration Options from the Xml Config file.
			/// </summary>
			private void SetScheduleFromConfigurationFile()
			{
				string basePath = AppDomain.CurrentDomain.BaseDirectory;
				if (basePath.EndsWith("\\")) { basePath = basePath.Substring(0, basePath.Length - 1); }
				string path = string.Format("{0}\\Scheduling\\scheduledefinition.xml", basePath);
				_manager.ProcessMonitor.Logger.Debug("Configuration File Path", path);
				XmlSerializer serializer = new XmlSerializer(typeof(SimpleScheduleManager.ScheduleDefinition));
				XmlTextReader reader = new XmlTextReader(path);
				reader.WhitespaceHandling = WhitespaceHandling.None;
				_definition = serializer.Deserialize(reader) as SimpleScheduleManager.ScheduleDefinition;
				reader = null;
				serializer = null;
			}
			#endregion
			#region Timer Events
			private void _timer_ZeroingProcess(object sender, System.Timers.ElapsedEventArgs e)
			{
				if (DateTime.Now.Second.Equals(0))
				{
					_timer.Interval = 60000;
					_timer.Elapsed -= new System.Timers.ElapsedEventHandler(_timer_ZeroingProcess);
					_timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
					_timer_Elapsed(sender, e);
				}
			}
			private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			{
				_manager.ProcessMonitor.Logger.Info("Timer Elapsed", DateTime.Now.ToString());
				if (MigrationIsScheduledToRunNow())
				{
					switch (_manager.State)
					{
						case DataMigrationState.Idle:
							_manager.ProcessMonitor.Logger.Info("DataMigration Manager is idle. Begin Processing.");
							_manager.BeginMigration();
							break;
						case DataMigrationState.Failed:
							_manager.ProcessMonitor.Logger.Warn("Data Migration is in failed state, Email <NotificationRecipients> alerting them.");
							break;
						default:
							_manager.ProcessMonitor.Logger.Warn("DataMigration Manager is still processing.  Skipping this iteration.");
							break;
					}
				}
			}
			#endregion
		}
	}
