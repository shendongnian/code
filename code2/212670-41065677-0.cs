    using System;
    public class Something
    {
        //
        private static  DateTime _saticConstructorTime;
        private         DateTime _instanceConstructorTime;
        //
        public static DateTime SaticConstructorTime
        {
            set { _saticConstructorTime = value; }
            get { return _saticConstructorTime ; }
        }
        public DateTime InstanceConstructorTime
        {
            set { _instanceConstructorTime = value; }
            get { return _instanceConstructorTime; }
        }
        //Set value to static propriety 
        static Something()
        {
            SaticConstructorTime = DateTime.Now;
            Console.WriteLine("Static constructor has been executed at: {0}",
                            SaticConstructorTime.ToLongTimeString());
        }
        //The second constructor started alone at the next instances
        public Something(string s)
        {
            InstanceConstructorTime = DateTime.Now;
            Console.WriteLine("New instances: "+ s +"\n");
        }
        public void TimeDisplay(string s)
        {
            Console.WriteLine("Instance \""+ s + "\" has been created at: " + InstanceConstructorTime.ToLongTimeString());
            Console.WriteLine("Static constructor has been created at: " + SaticConstructorTime.ToLongTimeString() + "\n");
        }
    }
    //
    class Client
    {
        static void Main()
        {
            Something somethingA = new Something("somethingA");
            System.Threading.Thread.Sleep(2000);
            Something somethingB = new Something("somethingB");
            
            somethingA.TimeDisplay("somethingA");
            somethingB.TimeDisplay("somethingB");
            System.Console.ReadKey();
        }
    }
    /* output :
      
    Static constructor has been executed at: 17:31:28
    New instances: somethingA
    New instances: somethingB
    Instance "somethingA" has been created at: 17:31:28
    Static constructor has been created at: 17:31:28
    Instance "somethingB" has been created at: 17:31:30
    Static constructor has been created at: 17:31:28
     */
    
