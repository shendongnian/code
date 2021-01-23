    public static IEnumerable<string> SplitRow(string row, char delimiter = ',')
    {
        var currentString = new StringBuilder();
        var inQuotes = false;
        var quoteIsEscaped = false; //Store when a quote has been escaped.
        row = string.Format("{0}{1}", row, delimiter); //We add new cells at the delimiter, so append one for the parser.
        foreach (var character in row.Select((val, index) => new {val, index}))
        {
            if (character.val == delimiter) //We hit a delimiter character...
            {
                if (!inQuotes) //Are we inside quotes? If not, we've hit the end of a cell value.
                {
                    Console.WriteLine(currentString);
                    yield return currentString.ToString();
                    currentString.Clear();
                }
                else
                {
                    currentString.Append(character.val);
                }
            } else {
                if (character.val != ' ')
                {
                    if(character.val == '"') //If we've hit a quote character...
                    {
                        if(character.val == '\"' && inQuotes) //Does it appear to be a closing quote?
                        {
                            if (row[character.index + 1] == character.val) //If the character afterwards is also a quote, this is to escape that (not a closing quote).
                            {
                                quoteIsEscaped = true; //Flag that we are escaped for the next character. Don't add the escaping quote.
                            }
                            else if (quoteIsEscaped)
                            {
                                quoteIsEscaped = false; //This is an escaped quote. Add it and revert quoteIsEscaped to false.
                                currentString.Append(character.val);
                            }
                            else
                            {
                                inQuotes = false;
                            }
                        }
                        else
                        {
                            if (!inQuotes)
                            {
                                inQuotes = true;
                            }
                            else
                            {
                                currentString.Append(character.val); //...It's a quote inside a quote.
                            }
                        }
                    }
                    else
                    {
                        currentString.Append(character.val);
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(currentString.ToString())) //Append only if not new cell
                    {
                        currentString.Append(character.val);
                    }
                }
            }
        }
    }
