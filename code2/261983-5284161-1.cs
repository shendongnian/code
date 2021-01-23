    public class DataType<T> where T : class
    {
        public T Value
        {
            get
            {
               // call ConvertFromBytes with linqBinary.ToArray()
               // not sure about the following; you might have to tweak it.
                return ConvertFromBytes((from d in Database
                       where d.Value = [Some Argument Passed]
                       select d.Value).
                First().ToArray());
            }
        }
    
        protected virtual T ConvertFromBytes(byte[] getBytes)
        {
            throw new NotImplementedException();
        }
    }
    
    public class StringClass : DataType<string>
    {
        protected override string ConvertFromBytes(byte[] getBytes)
        {
            return Encoding.UTF8.GetString(getBytes);
        }
    
    }
    public class ByteClass : DataType<byte[]>
    {
        protected override byte[] ConvertFromBytes(byte[] getBytes)
        {
            return getBytes;
        }
    }
