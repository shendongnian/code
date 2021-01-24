    using System;
    using System.Threading;
    
    public class Work
    {
        public static void Main()
        {
            // Start a thread that calls a parameterized static method.
            Thread newThread = new Thread(Work.DoWork);
            //create a class to hold multiple params
            DataClass objData = new DataClass();
            objData.Param1 = "value 1";
            objData.Param2 = "value 2";
            newThread.Start(objData);
    
            // Start a thread that calls a parameterized instance method.
            Work w = new Work();
            newThread = new Thread(w.DoMoreWork);
            newThread.Start(objData);
        }
    
        public static void DoWork(object data)
        {
            DataClass myData = (DataClass)data;
            Console.WriteLine("Static thread procedure. Data Param1='{0}'",
                data.Param1);
        }
    
        public void DoMoreWork(object data)
        {
            DataClass myData = (DataClass)data;
            Console.WriteLine("Instance thread procedure. Data Param2='{0}'",
                data.Param2);
        }
    }
