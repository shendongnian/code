    public class MyStreamReader : System.IO.StreamReader
    {
        public MyStreamReader(string path)
            : base(path)
        {
    
        }
        public override string ReadLine()
        {
            string result = string.Empty;
            int b = base.Read();
            while ((b != (int)',') && (b > 0))
            {
                result += this.CurrentEncoding.GetString(new byte[] { (byte)b });
                b = base.Read();
            }
            return result;
        }
    }
