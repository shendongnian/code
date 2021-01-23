    // Inside this method  
    public static Object Parse(ITree node){...}
    // Find one occurrence of
    case EsperEPL2GrammarParser.STRING_TYPE:
    {
	    return StringValue.ParseString(node.Text, requireUnescape);
    }
   
    // And change to
    case EsperEPL2GrammarParser.STRING_TYPE:
    {
	bool requireUnescape = true;
	if (node.Parent != null)
	{
		if (!String.IsNullOrEmpty(node.Parent.Text))
		{
			if (node.Parent.Text == "regexp")
			{
				requireUnescape = false;
			}
		}
	}
	return StringValue.ParseString(node.Text, requireUnescape);
    }
