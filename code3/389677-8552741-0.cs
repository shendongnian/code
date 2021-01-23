    void Test1(object a) {
        var x = a as IMyInterface;
        if (x != null) {
            // x implements IMyInterface, you can call SampleMethod
        }
    }
    void Test2(object a) {
        if (a is IMyInterface) {
            // a implements IMyInterface
            ((IMyInterface)a).SampleMethod();
        }
    }
