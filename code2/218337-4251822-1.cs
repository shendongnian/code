    void Main()
    {
    	new C().DumpFoo(); // C
    	A x=new C();
    	x.BaseDumpFoo(); //C
    }
    
    abstract class A {
      protected virtual string Foo() {
    	return "A";
      }
      public void BaseDumpFoo()
      {
      	Console.WriteLine(Foo());
      }
    }
    
    abstract class B : A {
      protected override string Foo() {
    	return "B";
      }
    }
    
    class C : B {
      protected override string Foo() {
    	return "C";
      }
      public void DumpFoo()
      {
    	Console.WriteLine(Foo());
      }
    }
