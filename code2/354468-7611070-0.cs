    public delegate void GenericMethod<T>(T arg);
    public delegate void StringMethod(string str);
    public delegate void ByteMethod(byte bt);
    public interface ITest<T>
    {
        GenericMethod<T> someMethod;
    }
    public class TestA : ITest<string>
    {
        public GenericMethod<string> someMethod
        {
            get
            {
                return stringMethod; //which is of type StringMethod(string str), defined above
            }
        }
    }
    public class TestB : ITest<byte>
    {
        public GenericMethod<byte> someMethod
        {
            get
            {
                return byteMethod; //which is of type ByteMethod(byte bt);, defined above
            }
        }
    }
