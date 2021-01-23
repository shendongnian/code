    class Base
    {
        static Dictionary<string, int> myStaticField = new Dictionary<string, int>();
    
        void MyMethod()
        {
            myStaticField[this.GetType().Name] = 42; 
        }
    }
