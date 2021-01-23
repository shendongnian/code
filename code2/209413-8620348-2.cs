    foreach (string current in options.ReferencedAssemblies)
	{
		stringBuilder.Append("/R:");
		stringBuilder.Append("\"");
		stringBuilder.Append(current);
		stringBuilder.Append("\"");
		stringBuilder.Append(" ");
	}
