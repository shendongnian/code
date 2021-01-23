    public class MyFirstObject {
      private string MyValue {get;set;}
      public void UpdateMyValue(string newValue) { MyValue = newValue; }
    }
    public class MySecondObject {
      MyFirstObject myFirstObject;
      public MySecondObject {
        myFirstObject = new MyFirstObject;
        myFirstObject.UpdateMyValue( "someNewValue" );
      }
    }
