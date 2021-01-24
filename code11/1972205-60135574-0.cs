        internal static void Start()
        {
            pollingInterval = TimeSpan.FromSeconds(1);
            quitThreadEvent = new ManualResetEvent(false);
            regenerationThread = new Thread(doStart);
            regenerationThread.Start();
        }
        internal static void doStart()
        {
            queue.Enqueue(new KeyValuePair<string, string>("user1", "password1"));
            queue.Enqueue(new KeyValuePair<string, string>("user2", "password2"));
            queue.Enqueue(new KeyValuePair<string, string>("user3", "password3"));
            while (!quitThreadEvent.WaitOne(pollingInterval))
            {
                // tempList isn't empty, I checked it putting logs here.
                if (true)
                {
                    var temp = new KeyValuePair<string, string>();
                    if (queue.TryDequeue(out temp))
                    {
                        string username = temp.Key;
                        string password = temp.Value;
                        // Method comes till here but doesn't execute the statement below and directly reach to end WriteToFile method.
                        Task.Run(async () =>
                        {
                            await tempFunc(username, password);
                            queue.Enqueue(new KeyValuePair<string, string>(username, password));
                        });
                    }
                    Console.WriteLine("End of the method.");
                    break;
                }
            }
        }
        internal static async Task tempFunc(string userName, string pwd)
        {
            Console.WriteLine($"UserName = {userName}, Pwd = {pwd}");
            await Task.Delay(1000);
        }
        static void Main(string[] args)
        {
            Start();
            Thread.Sleep(5000);
        }
`
