    private  string WordByIndex(string text, int index)
    {
        try
        {
            int start = index;
            while (char.IsLetterOrDigit(text[start]))
            {
                start--;
            }
            start++;
            text= text.Substring(start); 
            var result=Regex.Match(text,@"[a-zA-Z0-9]{1,}");
            
            return result.Value;
        }
        catch (Exception ex) { throw ex; }
        }
