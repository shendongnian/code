    public class MyConsole
    {
        private List<IO.StreamWriter> m_Outputs = new List<IO.StreamWriter>();
        public MyConsole() { }
        public MyConsole(string _file)
        {
            AddOutput(_file);
        }
        public void AddFile(string _file)
        {
            IO.StreamWriter writer = new IO.StreamWriter(_file)
            m_Outputs.Add(writer);
        }
        public void WriteLine(string _data)
        {
            foreach(IO.StreamWriter w in m_Outputs)
                w.WriteLine(_data);
        }
        
        public void Close()
        {
            foreach(IO.StreamWriter w in m_Outputs)
                w.Close();
        }
    } // eo class MyConsole
