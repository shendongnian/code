    private string ConvertMixedUpTextAndBase64(string value)
    {
        var delimiters = new char[] { '\n' };
        var possibles = value.Split(delimiters, 
                                    StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < possibles.Length - 1; i++)
        {
            if (possibles[i].EndsWith("Content-Transfer-Encoding: base64"))
            {
                var nextTokenPlain = DecodeBase64(possibles[i + 1]);
                if (!string.IsNullOrEmpty(nextTokenPlain))
                {
                    value = value.Replace(possibles[i + 1], nextTokenPlain);
                    i++;
                }
            }                
        }
        return value;
    }
    private string DecodeBase64(string text)
    {
        string result = null;
        try
        {
            var converted = Convert.FromBase64String(text);
            result = System.Text.Encoding.UTF8.GetString(converted);
        }
        catch (System.ArgumentNullException)
        {
            //handle it
        }
        catch (System.FormatException)
        {
            //handle it
        }
        return result;
    }
