		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.Threading;
		
		namespace MyShared.MyHelper
		{
			/// <summary>
			/// Helper classes for threads.
			/// </summary>
			public static class MyThread
			{
				/// <summary>
				/// Remembers a thread, until shutdown.
				/// On shutdown, we can double check that all of the threads we created have been shut down.
				/// </summary>
				/// <param name="thread">Thread we want to remember until shutdown.</param>
				/// <param name="newName">New name for thread.</param>
				public static void MyRememberThreadUntilShutdown(this Thread thread, string newName)
				{
					// Check whether the thread has previously been named
					// to avoid a possible InvalidOperationException.
					if (thread.Name == null)
					{
						thread.Name = "MyThread" + newName;
					}
					else
					{
						Console.Write("Error E20120118-1914. Unable to rename thread to \"{0}\" as it already has a name of \"{1}\".\n",
							newName, thread.Name);
					}
		
					ThreadList[newName] = thread;
				}
		
				/// <summary>
				/// This stores a list of all the threads we have running in the entire system.
				/// </summary>
				private static readonly Dictionary<string, Thread> ThreadList = new Dictionary<string, Thread>(); 
		
				/// <summary>
				/// On program, check that all of the threads we started have been exited.
				/// </summary>
				public static bool OnShutdownCheckThreadsForExit()
				{
					if (ThreadList.Count != 0)
					{
						foreach (var thread in ThreadList)
						{
							if (thread.Value.IsAlive)
							{
								Console.Write("Error E20120119-8152. Thread name \"{0}\" was not shut down properly on exit.\n",thread.Key);
							}
						}
						return false;
					}
					else
					{
						return true;
					}
				}
			}
		}
