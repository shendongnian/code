    public static class Word
    {
        //string being passed in is a word or phrase
        public static string UppercaseWords(this string value)
        {
            //make an array from character in word 
            //takes each letter from the word to create an array element 
            char[] array = value.ToCharArray();
    
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
    
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
    }
