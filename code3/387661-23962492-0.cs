            var builder = new StringBuilder(input[0].ToString());
            if (builder.Length > 0)
            {
                for (var index = 1; index < input.Length; index++)
                {
                    char prevChar = input[index - 1];
                    char nextChar = index + 1 < input.Length ? input[index + 1] : '\0';
                    bool isNextLower = Char.IsLower(nextChar);
                    bool isNextUpper = Char.IsUpper(nextChar);
                    bool isPresentUpper = Char.IsUpper(input[index]);
                    bool isPrevLower = Char.IsLower(prevChar);
                    bool isPrevUpper = Char.IsUpper(prevChar);
                    if(!string.IsNullOrWhiteSpace(prevChar.ToString()) && 
                        ((isPrevUpper&& isPresentUpper && isNextLower) || 
                        (isPrevLower&&isPresentUpper&&isNextLower)||
                        (isPrevLower&&isPresentUpper&&isNextUpper)))
                    {
                        builder.Append(' ');
                        builder.Append(input[index]);
                    }
                    else{
                    builder.Append(input[index]);
                    }
                }
            }
            return builder.ToString();
        }
