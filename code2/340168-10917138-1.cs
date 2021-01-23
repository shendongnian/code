private const string Indent = "\t";
private readonly int IndentLength = Indent.Length;
public void IncreaseIndent()
{
	// Increase indent
	indentLevel++;
	indentBuffer.Append(Indent);
	// If new line already started, insert another indent at the beginning
	if (!useIndent)
	{
		contentBuffer.Insert(0, Indent);
	}
}
public void DecreaseIndent() 
{
	// Only decrease the indent to zero.
	if (indentLevel > 0) 
	{
		indentLevel--;
		// Remove an indent from the string, if applicable
		if (indentBuffer.Length != 0) 
		{
			indentBuffer.Remove(indentBuffer.Length - IndentLength, IndentLength);
		}
	}
}
