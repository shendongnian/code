        public Dictionary<int, string> GetSubstringDic(string start, string end, string source, bool includeStartEnd, bool caseInsensitive)
    {
        int startIndex = -1;
        int endIndex = -1;
        int length = -1;
        int sourceLength = source.Length;
        Dictionary<int, string> result = new Dictionary<int, string>();
        try
        {
            //if just want to find string, case insensitive
            if (caseInsensitive)
            {
                source = source.ToLower();
                start = start.ToLower();
                end = end.ToLower();
            }
            //does start string exist
            startIndex = source.IndexOf(start);
            if (startIndex != -1)
            {
                //start to check for each instance of matches for the length of the source string
                while (startIndex < sourceLength && startIndex > -1)
                {
                    //does end string exist?
                    endIndex = source.IndexOf(end, startIndex + 1);
                    if (endIndex != -1)
                    {
                        //if we want to get length of string including the start and end strings
                        if (includeStartEnd)
                        {
                            //make sure to include the end string
                            length = (endIndex + end.Length) - startIndex;
                        }
                        else
                        {
                            //change start index to not include the start string
                            startIndex = startIndex + start.Length;
                            length = endIndex - startIndex;
                        }
                        //add to dictionary
                        result.Add(startIndex, source.Substring(startIndex, length));
                        //move start position up
                        startIndex = source.IndexOf(start, endIndex + 1);
                    }
                    else
                    {
                        //no end so break out of while;
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //Notify of Error
             result = new Dictionary<int, string>();
            StringBuilder g_Error = new StringBuilder();
            g_Error.AppendLine("GetSubstringDic: " + ex.Message.ToString());
            g_Error.AppendLine(ex.StackTrace.ToString());
        }
        return result;
    }
    public string GetSubstring(string start, string end, string source, bool includeStartEnd, bool caseInsensitive)
    {
        int startIndex = -1;
        int endIndex = -1;
        int length = -1;
        int sourceLength = source.Length;
        string result = string.Empty;
        try
        {
            if (caseInsensitive)
            {
                source = source.ToLower();
                start = start.ToLower();
                end = end.ToLower();
            }
            startIndex = source.IndexOf(start);
            if (startIndex != -1)
            {
                endIndex = source.IndexOf(end, startIndex + 1);
                if (endIndex != -1)
                {
                    if (includeStartEnd)
                    {
                        length = (endIndex + end.Length) - startIndex;
                    }
                    else
                    {
                        startIndex = startIndex + start.Length;
                        length = endIndex - startIndex;
                    }
                    result = source.Substring(startIndex, length);
                }
            }
        }
        catch (Exception ex)
        {
            //Notify of Error
            result = string.Empty;
            StringBuilder g_Error = new StringBuilder();
            g_Error.AppendLine("GetSubstring: " + ex.Message.ToString());
            g_Error.AppendLine(ex.StackTrace.ToString());
        }
        return result;
    }
