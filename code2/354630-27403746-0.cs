    public class MyCustomInt64 : CustomValueType<MyCustomInt64, Int64>
    {
        private MyCustomInt64(long value) : base(value) {}        
        public static implicit operator MyCustomInt64(long value) { return new MyCustomInt64(value); }
    }
