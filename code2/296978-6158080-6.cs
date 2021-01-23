    public class TestLock
    {
        private  object threadLock = new object();
                
        public void PrintOne()
        {
            lock (threadLock)
            {
                Console.WriteLine("One");
                var f = File.OpenWrite(@"C:\temp\file.txt"); //same static resource
                f.Close();
            }
        }
    
        public void PrintTwo()
        {
            lock (threadLock)
            {
                Console.WriteLine("Two");
                var f = File.OpenWrite(@"C:\temp\file.txt"); //same static resource
                f.Close();
            }
        }
    }
