    public class MyConsole
    {
        //private List<IO.StreamWriter> m_Outputs = new List<IO.StreamWriter>();
        private Dictionary<String, IO.StreamWriter> m_Outputs = new Dictionary<String, IO.StreamWriter>();
        public MyConsole() { }
        public MyConsole(string _token, string _file)
        {
            AddOutput(_token, _file);
        }
        public void AddOutput(string _token, string _file)
        {
            IO.StreamWriter writer = new IO.StreamWriter(_file)
            m_Outputs[_token] = writer;
        }
        public void WriteLine(string _token, string _data)
        {
            if(m_Outputs.ContainsKey(_token))
                m_Outputs[_token].WriteLine(_data);
        }
        
        public void Close()
        {
            foreach(KeyValuePair<String, IO.StreamWriter> pair in m_Outputs)
                pair.Value.Close();
        }
    } // eo class MyConsole
