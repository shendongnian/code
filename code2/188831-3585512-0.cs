    public class BaseClass {
         public virtual void SomeFunction(int a, int b) {}
    }
    public class Derived : BaseClass {
         public override SomeFunction(int a, int b) {
              base.SomeFunction(a, b * 10);
         }
    }
