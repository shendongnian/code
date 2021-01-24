    public class CharGroupRule
    {
        public char MainChar { get; }
    
        public char [] MappedCharacters { get; }
    
        public CharGroupRule(char mainChar, char[] mappedCharacters)
        {
            MainChar = mainChar;
            MappedCharacters = mappedCharacters;
        }
    }
