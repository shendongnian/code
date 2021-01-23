    public class InnerClass {
        public void MyMethod() { /* ... */ }
    }
    public InnerClass MyProperty { get; set; }
    protected virtual void CallMyMethod() {
        InnerClass cls = MyProperty;
        if (cls != null)
            cls.MyMethod();
    }
