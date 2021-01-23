    public static string Wordify(this string camelCaseWord)
        {
            /* CamelCaseWord will become Camel Case Word,  
              if the word is all upper, just return it*/
            if (!Regex.IsMatch(camelCaseWord, "[a-z]"))
                return camelCaseWord;
            return string.Join(" ", Regex.Split(camelCaseWord, @"(?<!^)(?=[A-Z])"));
        }
