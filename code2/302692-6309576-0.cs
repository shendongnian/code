        class Program
    {
        static void Main(string[] args)
        {
            ConcurrentQueue<DirectoryInfo> concurrentQueue = new ConcurrentQueue<DirectoryInfo>();
            GetAllDirectories(new DirectoryInfo(@"C:\local\oracle"), concurrentQueue);
            Action action = () =>{
                const string toFind = "ora";
                DirectoryInfo info;
                while(concurrentQueue.TryDequeue(out info))
                {
                    FindInFile(toFind, info);
                }
            };
            Parallel.Invoke(action, action, action, action);
            Console.WriteLine("total found " + _counter);
            Console.ReadKey();
        }
        static int _counter = 0;
        static void FindInFile(string textToFind,DirectoryInfo dirInfo)
        {
            var files =dirInfo.GetFiles();
            foreach(FileInfo file in files)
            {
                using (StreamReader reader = new StreamReader(file.FullName))
                {
                    string content = reader.ReadToEnd();
                    Match match = Regex.Match(content, textToFind, RegexOptions.Multiline);
                    
                    if(match.Success)
                    {
                        Interlocked.Increment(ref _counter);
                        Console.WriteLine(file.FullName + " found " + match.Captures.Count);
                        
                        foreach(var t in match.Captures)
                        {
                            Console.WriteLine("-------------> char index" + match.Index);
                        }
                    }
                }
            }
        }
        internal static void GetAllDirectories(DirectoryInfo root, ConcurrentQueue<DirectoryInfo> values)
        {
            foreach (var di in root.GetDirectories())
            {
                GetAllDirectories(di, values);
                values.Enqueue(di);
            }
        }
    }
