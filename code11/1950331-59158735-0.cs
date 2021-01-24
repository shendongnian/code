    using System;
    
    namespace MY_PRIMARY
    {
        public partial class SomethingHere
        {
            public Boolean holiday { get; set; } = false;
            public int age { get; set; } = 18;
            //etc... 
        }
    
        public class Program
        {
            public int AddNumbers(int number1, int number2)
            {
                int result = number1 + number2;
                return result;
            }
        }
    } 
    
    namespace MY_SECONDARY
    {
        public partial class SomethingElseHere
        {
            public Boolean holiday { get; set; } = false;
            public int age { get; set; } = 18;
            //etc... 
        }
    
        class Program
        {
            static void Main()
            {    
                MY_PRIMARY.Program outer = new MY_PRIMARY.Program();
                outer.AddNumbers(3, 18);   
            }
        }
    }
