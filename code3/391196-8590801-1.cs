    public class MyClass
    {
        private Dictionary<char, char> dict = new Dictionary<char, char>();
        
        public MyClass()
        {
            dict.Add('A', '1');
            dict.Add('B', '2');
            // ... and so on ...
        }
        
        public char TranslateChar(char input)
        {
            char result;
            if (dict.TryGetValue(input, out result))
            {
                return result;
            }
            return '?';
        }
    }
