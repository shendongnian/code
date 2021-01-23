    public class NameAndNumber
    {
        public NameAndNumber(string s)
        {
            OriginalString = s;
            Match match = Regex.Match(s,@"^(.*?)(\d*)$");
            Name = match.Groups[1].Value;
            int number;
            int.TryParse(match.Groups[2].Value, out number);
            Number = number; //will get default value when blank
        }
        public string OriginalString { get; private set; }
        public string Name { get; private set; }
        public int Number { get; private set; }
    }
