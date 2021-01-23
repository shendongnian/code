        class Program
    {
        static string UppercaseWords(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }
    
        static void Main()
        {
            // Uppercase words in these strings.
            const string value1 = "something in the way";
            const string value2 = "dot net PERLS";
            const string value3 = "String_two;three";
            const string value4 = " sam";
            // ... Compute the uppercase strings.
            Console.WriteLine(UppercaseWords(value1));
            Console.WriteLine(UppercaseWords(value2));
            Console.WriteLine(UppercaseWords(value3));
            Console.WriteLine(UppercaseWords(value4));
        }
    }
    Output
    
    Something In The Way
    Dot Net PERLS
    String_two;three
     Sam
