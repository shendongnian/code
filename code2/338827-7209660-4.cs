	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using System.Diagnostics;
	using System.Threading;
	namespace ParallelButtons_7208779
	{
		public partial class frmMain : Form
		{
			public frmMain()
			{
				InitializeComponent();
				tslblRunStatus.Text = "Updating: please wait...";
				tslblFinalStatus.Text = "";
				Thread BackgroundThread =
					new Thread(() => TwoParallelCalls_UpdateOnlyOnReturn());
				BackgroundThread.Start();
				// tmrUpdateStatus is a timer component dropped onto the
				// form in design mode. it's initial settings are defaults
				// Interval=100, Enabled=false, and it's Tick event has 
				// been hooked up to tmrUpdateStatus_tick
				tmrUpdateStatus.Start();
			}
			// the nice thing about the component timer is that we don't 
			// have to worry about doing an Invoke, we already know that the
			// Tick event is happening on the UI thread.
			private void tmrUpdateStatus_Tick(object sender, EventArgs e)
			{
				// in case a tick fires after both functions complete
				if ((currentCount == -1) || (allowedCount != 1))
				{
					tslblRunStatus.Text =
						string.Format(
							"[running...] Using {0} of {1}",
							runCurrentCount, runAllowedCount
						);
				}
				else
				{
					// We can use this to stop the timer since we are doing the
					// check in here. If we didn't need to prevent an extra
					// update after the functions were complete, we could skip
					// the check in here and stop it elsewhere. (see below)
					tmrUpdateStatus.Stop();
				}
			}
			// The nice thing about having a common method that fires both 
			// functions and then waits for both is that no special thread
			// synchronization is needed.
			//
			// Otherwise there would be a need to use some sort of 
			// sychronization method (e.g. Semaphore, Mutex, lock) to ensure 
			// that the update is handled correctly.
			private void TwoParallelCalls_UpdateOnlyOnReturn()
			{
				// initializing with Lambdas that just set the fields to the
				// result of the function calls.
				Thread thread1 = new Thread(() => currentCount = func1());
				Thread thread2 = new Thread(() => allowedCount = func2());
				// start both threads and wait for both to finish
				thread1.Start(); 
				thread2.Start();			
				thread1.Join(); 
				thread2.Join();
				// using Invoke to safely update the .Forms GUI component.
				Invoke((Action)
					(() => 
					{
						// this stops the UI update timer from this function, 
						// we can do this instead of checking status in the
						// Tick event if we can tolerate extra updates.
						tmrUpdateStatus.Stop();
						// set the final status test to the label
						tslblFinalStatus.Text =
							string.Format(
								"[final] Used {0} of {1}",
								currentCount, allowedCount
							);
					}
					));
			}
			#region Background Thread Functionality
			// The following functions are just dummy methods to udpate something
			// in the background we can use to watch the results on the UI.
			// In this section, I just have two methods that run in the background
			// updating some member fields. 
			// fields for intermediate values (set internally while running)
			int runCurrentCount = -1;
			int runAllowedCount = -1;
			// fields for a final result (set externally using return value)
			int currentCount = -1;
			int allowedCount = -1;
			// holds how long we want the test threads to run
			TimeSpan TestRunTimespan = TimeSpan.FromSeconds(5);
			// These methods use the System.Diagnostics.Stopwatch class which
			// has been around since .NET 2.0.
			// If you are really wanting to do a task that requires something
			// to happen at particular intervals, you should probably look at
			// an interval timer of some sort. There are several timers
			// available, There are various concerns when choosing one, so 
			// I highly recommend doing research (Stack Overflow has some
			// good answers on this issue if you search on 'Timer'.)
			//
			// Timers: System.Windows.Forms.Timer, System.Threading.Timer,
			// System.Windows.Threading.DispatcherTimer, System.Timers.Timer
			private int func1()
			{
				Stopwatch stopWatch = new Stopwatch();
				stopWatch.Start();
				while (stopWatch.Elapsed < TestRunTimespan)
				{
					runCurrentCount += 5;
					Thread.Sleep(100);
				}
				runCurrentCount += 10;
				return runCurrentCount;
			}
			private int func2()
			{
				Stopwatch stopWatch = new Stopwatch();
				stopWatch.Start();
				while (stopWatch.Elapsed < TestRunTimespan)
				{
					runAllowedCount += 10;
					Thread.Sleep(100);
				}
				runAllowedCount += 10;
				return runAllowedCount;
			}
			#endregion
		}
	}
