    class Program {
        static void Main(string[] args) {
            var task = Task.Factory.StartNew(() => {
                Thread.CurrentThread.Name = "foo";
                Thread.Sleep(10000);   // Use Debug + Break to see it
            });
            task.Wait();
        }
    }
