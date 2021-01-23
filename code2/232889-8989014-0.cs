    static class Extensions
    {
        private static readonly char[] DefaultDelimeters = new char[]{' ', '.'};
        public string LastWord(this string StringValue)
        {
            return LastWord(StringValue, DefaultDelimeters);
        }
        public string LastWord(this string StringValue, char[] Delimeters)
        {
            int index = StringValue.LastIndexOfAny(Delimeters);
            if(index>-1)
                return StringValue.Substring(index);
            else
                return null;
        }
    }
    class Application
    {
        public void DoWork()
        {
            string sentence = "STRIP, HR 3/16 X 1 1/2 X 1 5/8 + API";
            string lastWord = sentence.LastWord();
        }
    }
