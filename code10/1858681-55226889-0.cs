    var sb = new StringBuilder("a1b2c3d4");
	for (int i = sb.Length - 1; i >= 0; i--)
	{
		if (char.IsNumber(sb[i]))
		{
			sb.Remove(i, 1);
		}	
	}
		
    var result = sb.ToString();
