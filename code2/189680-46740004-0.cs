            public static string FirstCharToUpper(string text, bool firstWordOnly = true)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return text;
                }
                else
                {
                    if (firstWordOnly)
                    {
                        string[] words = text.Split(' ');
                        string firstWord = words.First();
                        firstWord = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(firstWord.ToLower());
                        words[0] = firstWord;
                        return string.Join(" ", words);
                    }
                    else
                    {
                        return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                    }
                }
            } catch (Exception ex)
            {
                Log.Exc(ex);
                return text;
            }
        }
