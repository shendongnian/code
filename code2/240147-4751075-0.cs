    //In a class file 
    namespace Global.Functions //Or whatever you call it
    {
      public class Numbers
      {
        private Numbers() {} // Private ctor for class with all static methods.
    
        public static int MyFunction()
        {
          return 22;
        }
      }
    }
    //Use it in Other class 
    using Global.Functions
    int Age = Numbers.MyFunction();
