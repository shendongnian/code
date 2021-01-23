        public void test()
        {
            const string WithUnicodeCharacter = "a hebrew character:\uFB2F";
            const string WithoutUnicodeCharacter = "an ANSI character:Æ";
            bool hasUnicode;
            //true
            hasUnicode = ContainsUnicodeCharacter(WithUnicodeCharacter);
            Console.WriteLine(hasUnicode);
            //false
            hasUnicode = ContainsUnicodeCharacter(WithoutUnicodeCharacter);
            Console.WriteLine(hasUnicode);
        }
        public bool ContainsUnicodeCharacter(string input)
        {
            return input.ToCharArray().Any(c => c > 255);
        }
