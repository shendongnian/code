    text = System.Text.RegularExpressions.Regex.Replace(
            text, 
            @"^[^|]{3}(?:\r\n|[\r\n]|$)", 
            "", 
            System.Text.RegularExpressions.RegexOptions.Multiline);
