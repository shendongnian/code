    public class SelfParser : iExample
    {
        public iExample Parse(string value)
        {
            return new SelfParser();
        }
    }
