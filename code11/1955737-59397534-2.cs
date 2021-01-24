    var sbRange = new StringBuilder();
	for (int i = 1; i <= 10; i++)
	{
		sbRange.Append($"{i} ");
	}
	// You can use a string and trim it (there is a space in excess at the end)
	string range = sbRange.ToString().Trim();
    sb.AppendLine($"Id {range}");
	sb.AppendLine($"Roll# {range}");
