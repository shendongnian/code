    class YourClass
    {
      private MyEnum _myStateEnum; // Wrap this with a public property
      private MyInnerClass _myStateLogic; // Change this with appropriate type when above changes
      public void AnExampleMethod()
      {
          _myStateLogic.AnExampleMethod();
      }
      internal abstract class MyInnerClass
      {
          public virtual abstract void AnExampleMethod();
      }
      internal class MyOtherInnerClass1: MyInnerClass
      {
          public override void AnExampleMethod() { }
      }
      internal class MyOtherInnerClass2: MyInnerClass
      {
          public override void AnExampleMethod() { }
      }
    }  
