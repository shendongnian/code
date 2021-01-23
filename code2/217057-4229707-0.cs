    class MyRandom : System.Random 
    {
         public override double NextDouble()
         {     
              // return your fake random double here.
         }
    }
    class TestFixture 
    {
         public void UnitTest()
         {
              // Create the unit under test
              foo unit = new foo();
              
              // use reflection to inject a mock instance
              typeof(foo)
                 .GetField("r", BindingFlags.Instance | BindingFlags.NonPublic)
                 .SetValue(unit, new MyRandom());
              // ACT: call method
              var result = foo.bar();
              
              // examine results
          }
     }
              
