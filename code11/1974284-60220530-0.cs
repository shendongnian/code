 enum TestConditions
 {
   One = 12234,
   Two = 12345,
   Three=54321,
      
 }
 //Enum 
 Console.WriteLine((int)TestConditions.One); //Output = 12234
 Console.WriteLine(TestConditions.One); //Output = One
 Console.WriteLine((TestConditions)12234); // Output = One
*Perhaps you could you use a static class like this*
 public static class TestCondition
 {
      public static string One = "12234";
      public static string Two = "12345";
      public static int Three = 54321;
 }
