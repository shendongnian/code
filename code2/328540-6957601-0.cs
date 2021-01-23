    public class Work
    {
        public static void Main()
        {
            memberdetail md = new memberdetail(arg0, arg1, arg3)
            Thread newThread = new Thread(Work.DoWork);
    
            // Use the overload of the Start method that has a
            // parameter of type Object.
            newThread.Start(md);
        }
    
        public static void DoWork(object data)
        {
            Console.WriteLine("Static thread procedure. Data='{0}'", data);
            // You can convert it here
            memberdetail md = data as memberdetail;
            if(md != null)
            {
               // Use md
            }
        }
    }
