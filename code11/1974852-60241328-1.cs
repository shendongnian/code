	StringBuilder builder = new StringBuilder();
			
	if (num == 0)
	{
		builder.Append('0');
	}
	else
	{
		while (num != 0)
		{
		    builder.Append((char)('0' + (num & 1)));
			num >>= 1;
		}
	}
    Console.WriteLine(builder.ToString());
