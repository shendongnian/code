    using System;
    public class C {
        
       public static void TestMethod(int? x = 10, int? y = 20)
            {
                var message = $"The value of x is {x.Value} and y is {y.Value}";
            }
        
        public void M() {
            
            TestMethod(null, null);
            TestMethod();
            
        }
    }
