    var delimiters = new char[] { /* non-base64 ASCII chars */ };
    var possibles = value.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
    //need to tweak to include padding chars in matches, but still split on padding?
    //maybe better off creating a regex to match base64 + padding
    //and using Regex.Split?
    foreach(var match in possibles)
    {
        try
        {
            var converted = Convert.FromBase64String(match);
            var text = System.Text.Encoding.UTF8.GetString(converted);
            if(!string.IsNullOrEmpty(text))
            {
                value = value.Replace(match, text);
            }
        } 
        catch (System.ArgumentNullException) 
        {
            //handle it
        }
        catch (System.FormatException) 
        {
            //handle it
        }
    }
