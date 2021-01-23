    class Pipe {
        MemoryStream _ms;
        StreamReader _sr;
        StreamWriter _sw;
        public Pipe()
        {
           _ms = new MemoryStream();
           _sr = new StreamReader(_ms);
           _sw = new StreamWriter(_ms);
        }
        public void PutChar(char c) { _sw.Write(c) }
        public char GetChar() { return _sw.Read();  }
    }
