    public class Parser
    {
        private readonly string _file;
    
        private Dictionary<string, string> _nics;
    
        public Parser(string file)
        {
            _file = file;
            _nics = new Dictionary<string, string>();
        }
    
        public void Parse()
        {
            StringBuilder value = new StringBuilder();
            string key = string.Empty;
    
            using (var rdr = new StreamReader(_file))
            {
                bool firstTime = true;
    
                while (rdr.Peek() > 0)
                {
                    var line = rdr.ReadLine().Trim();
    
                    if (line.StartsWith("[") && !line.Contains("."))
                    {
                        if (!firstTime)
                        {
                            _nics.Add(key, value.ToString());
                        }
                        else
                        {
                            firstTime = false;
                        }
    
                        key = line;
                        value.Length = 0;
                    }
                    else
                    {
                        value.AppendLine(line);
                    }
                }
    
                _nics.Add(key, value.ToString());
            }
        }
    
        public void AddKey(string key, string value)
        {
            if (key != string.Empty)
            {
                _nics.Add(key, value);
            }
        }
    
        public Dictionary<string, string> Cards
        {
            get { return _nics; }
        }
    }
