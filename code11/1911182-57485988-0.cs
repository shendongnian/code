    public abstract class SomeAbstractClass { }
    
    public class ClassA : SomeAbstractClass {
        protected virtual void Test() { }    
    }
    
    public abstract class ClassB : ClassA {
    	protected override abstract void Test();
    }
    
    public class ClassC : ClassB {
    	protected override void Test() { }
    }
