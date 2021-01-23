        var sbOut = new StringBuilder();
        var combined = String.Join(Environment.NewLine, textbox1.Lines);
        //split string on "name:" rather than on lines
        string[] lines = combined.Split(new string[] { "name:" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var item in lines)
        {
            //add name back in as split strips it out
            sbOut.Append("name:");
            //find first space
            var found = item.IndexOf(" ");
            //add username IMPORTANT assumes no spaces in username
            sbOut.Append(item.Substring(0, found + 1));
            //Add thumbnail:example.com if it doesn't exist
            if (!item.Substring(found + 1).StartsWith("thumbnail:example.com"))                
                sbOut.Append("thumbnail:example.com ");
            //Add the rest of the string
            sbOut.Append(item.Substring(found + 1));
            
            
        }
