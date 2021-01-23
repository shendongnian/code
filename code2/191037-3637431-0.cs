    interface IDisplayable
    {
        void GetInfo();
        public string Info;
    }
    class Human : IDisplayable
    {
       public string Info
       { 
        get 
        { 
            return "";//your info here
        }
        set;
       }
       
       public void GetInfo()
       {
           Console.WriteLine("The person is " + Info)
       }
    }
