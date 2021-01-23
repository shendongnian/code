	public abstract class AB {
	  public MyModel Model;
	}
	public class A : AB {
          MyModel MyModel;
	  public A() {
                MyModel = new MyModelA();
                Model = MyModel;
	  }
	  public void AMethod() {
                //just use MyModel
	  }
	  public void AnotherMethod() {
		MyModel.NewInt = 123;
	  }
	}
	public abstract class MyModel {
	}
	public class MyModelA : MyModel {
	  // new properties
	  public int NewInt {get;set;}
	}
