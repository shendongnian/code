    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace ConsoleApplicationWebBrowser
    {
        // by Noseratio - https://stackoverflow.com/users/1768303/noseratio
        class Program
        {
            // Entry Point of the console app
            static void Main(string[] args)
            {
                try
                {
                    // download each page and dump the content
                    var task = MessageLoopWorker.Run(DoWorkAsync,
                        "http://www.example.com", "http://www.example.net", "http://www.example.org");
                    task.Wait();
                    Console.WriteLine("DoWorkAsync completed.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("DoWorkAsync failed: " + ex.Message);
                }
    
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();
            }
    
            // navigate WebBrowser to the list of urls in a loop
            static async Task<object> DoWorkAsync(object[] args)
            {
                Console.WriteLine("Start working.");
    
                using (var wb = new WebBrowser())
                {
                    wb.ScriptErrorsSuppressed = true;
    
                    TaskCompletionSource<bool> tcs = null;
                    WebBrowserDocumentCompletedEventHandler documentCompletedHandler = (s, e) =>
                        tcs.TrySetResult(true);
    
                    // navigate to each URL in the list
                    foreach (var url in args)
                    {
                        tcs = new TaskCompletionSource<bool>();
                        wb.DocumentCompleted += documentCompletedHandler;
                        try
                        {
                            wb.Navigate(url.ToString());
                            // await for DocumentCompleted
                            await tcs.Task;
                        }
                        finally
                        {
                            wb.DocumentCompleted -= documentCompletedHandler;
                        }
                        // the DOM is ready
                        Console.WriteLine(url.ToString());
                        Console.WriteLine(wb.Document.Body.OuterHtml);
                    }
                }
    
                Console.WriteLine("End working.");
                return null;
            }
    
        }
    
        // a helper class to start the message loop and execute an asynchronous task
        public static class MessageLoopWorker
        {
            public static async Task<object> Run(Func<object[], Task<object>> worker, params object[] args)
            {
                var tcs = new TaskCompletionSource<object>();
    
                var thread = new Thread(() =>
                {
                    EventHandler idleHandler = null;
    
                    idleHandler = async (s, e) =>
                    {
                        // handle Application.Idle just once
                        Application.Idle -= idleHandler;
    
                        // return to the message loop
                        await Task.Yield();
    
                        // and continue asynchronously
                        // propogate the result or exception
                        try
                        {
                            var result = await worker(args);
                            tcs.SetResult(result);
                        }
                        catch (Exception ex)
                        {
                            tcs.SetException(ex);
                        }
    
                        // signal to exit the message loop
                        // Application.Run will exit at this point
                        Application.ExitThread();
                    };
    
                    // handle Application.Idle just once
                    // to make sure we're inside the message loop
                    // and SynchronizationContext has been correctly installed
                    Application.Idle += idleHandler;
                    Application.Run();
                });
    
                // set STA model for the new thread
                thread.SetApartmentState(ApartmentState.STA);
    
                // start the thread and await for the task
                thread.Start();
                try
                {
                    return await tcs.Task;
                }
                finally
                {
                    thread.Join();
                }
            }
        }
    }
