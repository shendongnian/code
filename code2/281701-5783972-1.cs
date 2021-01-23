    string input = "Something with &mdash; or other character entities.";
    StringBuilder output = new StringBuilder(input.Length);
    
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == '&')
        {
            int startOfEntity = i; // just for easier reading
            int endOfEntity = input.IndexOf(';', startOfEntity);
            string entity = input.Substring(startOfEntity, endOfEntity - startOfEntity);
            int unicodeNumber = (int)(HttpUtility.HtmlDecode(entity)[0]);
            output.Append("&#" + unicodeNumber + ";");
            i = endOfEntity; // continue parsing after the end of the entity
        }
        else
            output.Append(input[i]);
    }
