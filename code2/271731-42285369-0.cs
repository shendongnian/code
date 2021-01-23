    class Program
    {
        protected static Dictionary<string, string> _tags = new Dictionary<string,string>();
        static void Main(string[] args)
        {
            string strValue;
            _tags.Add("101", "C#");
            _tags.Add("102", "ASP.NET");
            if (_tags.ContainsKey("101"))
            {
                strValue = _tags["101"];
                Console.WriteLine(strValue);
            }
            if (_tags.TryGetValue("101", out strValue))
            {
                Console.WriteLine(strValue);
            }
        }
    }
