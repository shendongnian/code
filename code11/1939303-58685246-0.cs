        var span = "<span>X</span>間違<span>う</span><span>Y</span>";
        var plain = span.Replace("<span>", "").Replace("</span>", "").Trim();
        var sb = new StringBuilder(string.Empty); 
        for(int x =0; x < plain.Length; x++)
        {
            sb.Append($"<span>{plain[x]}</span>");
            
        }
