    foreach (var kvp in config.Keys)
    {
        var sb = new StringBuilder(kvp.Key).Append('=');
        for(int i = 0; i < kvp.Value.Length; i++)
        {
            sb.Append(kvp.Value[i]);
            
            // skip comma for last item
            if(i < kvp.Value.Length - 1)
            {
                sb.Append(',');
            }
        }
        
        file.WriteLine(sb.ToString());
    }
