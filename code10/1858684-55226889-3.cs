    var sb = new StringBuilder();
	foreach (var ch in "a1b2c3d4")
	{
		if (!char.IsNumber(ch))
		{
            sb.Append(ch);
		}	
	}
		
    var result = sb.ToString();
