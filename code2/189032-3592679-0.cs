    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    namespace ConsoleApplication1 {
        class Program {
            static void Main() {
                StreamWriter Writer = new StreamWriter("file");
                Action<int> ThreadProcedure = (i) => {
                    // A thread may perform many actions and write out the result after each action
                    // The outer loop here represents the multiple actions this thread will take
                    for (int x = 0; x < 5; x++) {
                        // Here is where the thread would generate the data for this action
                        // Well simulate work time using a call to Sleep
                        Thread.Sleep(1000);
                        // After generating the data the thread needs to lock the Writer before using it.
                        lock (Writer) {
                            // Here we'll write a few lines to the Writer
                            for (int y = 0; y < 5; y++) {
                                Writer.WriteLine("Thread id = {0}; Action id = {1}; Line id = {2}", i, x, y);
                            }
                        }
                    }
                };
                //Now that we have a delegate for the thread code lets make a few instances
                List<IAsyncResult> AsyncResultList = new List<IAsyncResult>();
                for (int w = 0; w < 5; w++) {
                    AsyncResultList.Add(ThreadProcedure.BeginInvoke(w, null, null));
                }
                // Wait for all threads to complete
                foreach (IAsyncResult r in AsyncResultList) {
                    r.AsyncWaitHandle.WaitOne();
                }
                // Flush/Close the writer so all data goes to disk
                Writer.Flush();
                Writer.Close();
            }
        }
    }
