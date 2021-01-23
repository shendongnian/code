        static void Main(string[] args)
        {
            MyService my = new MyService();
            my.HelloCompleted +=new HelloCompletedEventHandler(my_HelloCompleted);
            my.HelloAsync();
            Console.WriteLine("Called webservice");
            Console.ReadKey();
        }
        private static void my_HelloCompleted(object sender, HelloCompletedEventArgs e)
        {
            Console.Write("Webservice finished executing in my_HelloCompleted.");
        }
