    public class Program.cs
    {
        public static myFlag = false;
        public void Main()
        {
            thread = new Thread(new ThreadStart(DoWork));
            thread.Start();
            Console.ReadLine();
            myFlag = true;
        }
        public static DoWork()
        {
            while(myFlag == false)
            {
                DoMoreWork();
            }
            CleanUp()
        }
        public static DoMoreWork() { }
        public static CleanUp() { }
    
    }
