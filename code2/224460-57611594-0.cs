    private static List<string> SplitWordsByLength(string str, int maxLength)
    {
        List<string> chunks = new List<string>();
        while (str.Length > 0)
        {
            if (str.Length <= maxLength)                    //if remaining string is less than length, add to list and break out of loop
            {
                chunks.Add(str);
                break;
            }
            string chunk = str.Substring(0, maxLength);     //Get maxLength chunk from string.
            if (char.IsWhiteSpace(str[maxLength]))          //if next char is a space, we can use the whole chunk and remove the space for the next line
            {
                chunks.Add(chunk);
                str = str.Substring(chunk.Length + 1);      //Remove chunk plus space from original string
            }
            else
            {
                int splitIndex = chunk.LastIndexOf(' ');    //Find last space in chunk.
                if (splitIndex != -1)                       //If space exists in string,
                    chunk = chunk.Substring(0, splitIndex); //  remove chars after space.
                str = str.Substring(chunk.Length + (splitIndex == -1 ? 0 : 1));      //Remove chunk plus space (if found) from original string
                chunks.Add(chunk);                          //Add to list
            }
        }
        return chunks;
    }
