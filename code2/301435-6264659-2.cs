    public class MyDataType
    {
        private MyDataType()
        {
            ...
        }
        internal static MyDataType Parse(string someString)
        {
            MyDataType newOne = new MyDataType();
            newOne.Value = ... //int.Parse(someString); ?
        }
        public int Value { get; private set; }
    }
