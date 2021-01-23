    public class MyClass: IBinarySerializable
    {
        public int X {get;set;}
        public byte[] GetBytes()
        {
            return BitConverter.GetBytes(X); // and anyother
        }
    }
