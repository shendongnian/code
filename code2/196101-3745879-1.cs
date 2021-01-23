     var sb = new StringBuilder();
     bool first = true;
     foreach (var foo in items) {
        if (first)
            first = false;
        else
            sb.Append('&');
        
        // for example:
        var escapedValue = System.Web.HttpUtility.UrlEncode(foo);
        sb.Append(key).Append('=').Append(escapedValue);
     }
     var s = sb.ToString();
