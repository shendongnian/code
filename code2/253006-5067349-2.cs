    public IEnumerable<ReturnData> toto()
    {
        using (StreamReader stream = new StreamReader(File.OpenRead(""), Encoding.UTF8))
        {
            char[] buffer = new char[1];
            while (stream.Peek() >= 0)
            {
                ReturnData result;
                try
                {
                    int readCount = stream.Read(buffer, 0, 1);
                    result = new ReturnData(new string(buffer, 0, readCount));
                }
                catch (Exception exc)
                {
                    result = new ReturnData(exc);
                }
                yield return result;
            }
        }
    }
    public class ReturnData
    {
        public string Data { get; private set; }
        public Exception Error { get; private set; }
        public bool HasError { get { return Error != null; } }
        public ReturnData(string data)
        {
            this.Data = data;
        }
        public ReturnData(Exception exc)
        {
            this.Error = exc;
        }
    }
