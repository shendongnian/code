    public static class TestExtensions
    {
      public static void ShouldEqual( this YourType subject, YourType other )
      {
         // Check parameters for null here if needed
         if( !subject.Equals( other ) )
         {
           // custom logging here
           Assert.Fail("Objects are not equal"); // test fails
         }
      }
    }
