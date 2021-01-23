    interface IMyWrapper<T> { T Value {get; }}
    public class StringWrapper: IMyMarker<string> { ... }
    public class IntWrapper: IMyMarker<int> { ... }
    
    void MyMethod(IMyMarker wrapper)
    {
    }
