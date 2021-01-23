	using System;
	using System.ComponentModel;
	using System.Diagnostics.CodeAnalysis;
	using System.Threading;
	using System.Windows.Threading;
	namespace DispatcherFun
	{
		public static class Program
		{
			public static void Main(string[] args)
			{
				var d = Dispatcher.CurrentDispatcher;
				Action action = () => Console.WriteLine("Dispatcher invoked me!");
				var worker = new BackgroundWorker();
				worker.DoWork += SomeWork;
				//worker.RunWorkerAsync( (Action) delegate { Console.WriteLine("This works!"); } );
				worker.RunWorkerAsync((Action)(() =>
				{
					d.Invoke(action);
				}));
				while (worker.IsBusy)
				{
					Dispatcher.CurrentDispatcher.DoEvents();
					Thread.Yield();
					Thread.Sleep(50);
				}
			}
			private static void SomeWork(object sender, DoWorkEventArgs e)
			{
				(e.Argument as Action)();
			}
			// Based On: http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherframe.aspx
			[SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
			public static void DoEvents(this Dispatcher dispatcher)
			{
				if (dispatcher != null)
				{
					// This is the "WPF" way:
					try
					{
						DispatcherFrame frame = new DispatcherFrame();
						dispatcher.Invoke(DispatcherPriority.Background, new DispatcherOperationCallback(ExitFrame), frame);
						Dispatcher.PushFrame(frame);
					}
					catch { /* do nothing */ }
					// This is the "WinForms" way (make sure to add a reference to "System.Windows.Forms" for this to work):
					try
					{
						dispatcher.Invoke(System.Windows.Forms.Application.DoEvents, DispatcherPriority.Send);
					}
					catch { /* do nothing */ }
				}
			}
			private static object ExitFrame(object f)
			{
				try
				{
					((DispatcherFrame)f).Continue = false;
				}
				catch { /* do nothing */ }
				return null;
			}
		}
	}
