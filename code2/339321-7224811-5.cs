    interface IFoo {
    }
    interface IBar {
    }
    interface IFooBar {
    }
    class FooBar : IFooBar {
    }
    void MyMethod(IFooBar f) {
    }
    void Test() {
        FooBar fb = new FooBar();
        MyMethod(fb);
    }
