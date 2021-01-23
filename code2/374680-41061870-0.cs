        if (System.Text.RegularExpressions.Regex.IsMatch(txt.Text, @"[a-zA-Z]") && 
            System.Text.RegularExpressions.Regex.IsMatch(txt.Text, @"[0-9]")      
        {
            // Success - It is alphanumric
        }
        else   
        {
            // Error - It is not alphanumric
        }
