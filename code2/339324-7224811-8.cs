    interface IFoo {
    }
    interface IBar {
    }
    interface IFooBar : IFoo, IBar {
    }
    class FooBar : IFooBar {
    }
    void MyMethod(IFooBar f) {
    }
    void Test() {
        FooBar fb = new FooBar();
        MyMethod(fb);
    }
