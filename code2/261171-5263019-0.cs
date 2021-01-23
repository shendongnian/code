    public class MyObject
    {
         public MyObject(object A, object B, object C)
         {
              // Assign your dependencies to whatever
         }
    }
    Mock<MyObject> mockObject = new Mock<MyObject>();
    Mock<MyObject> mockObject = new Mock<MyObject>(null, null, null); // Pass Nulls to specific constructor arguments, or 0 if int, etc
