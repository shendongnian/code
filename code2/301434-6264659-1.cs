    public class MyDataType
    {
        private MyDataType()
        {
            ...
        }
        internal static MyDataType Parse(string someString)
        {
            MyDataType newOne = new MyDataType();
            newOne.MyReadOnlyProperty = ...
        }
        public int MyReadOnlyProperty { get; private set; }
    }
