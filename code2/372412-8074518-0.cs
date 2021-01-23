     class MyClass
    {
        public delegate void CustomDelegate();
        public event CustomDelegate CustomEvent;
        public void RaiseAnEvent()
        {
            CustomEvent();
        }
    }
  
    sealed class Program 
    {
       
        
        static void Main()
        {
            MyClass ms = new MyClass();
            ms.CustomEvent += new MyClass.CustomDelegate(ms_CustomEvent);
            ms.RaiseAnEvent();
            
            Console.ReadLine();
        }
        static void ms_CustomEvent()
        {
            Console.WriteLine("Event invoked");
        }
    }
