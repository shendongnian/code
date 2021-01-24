	public string Process(ProcessOptions options, string text)
	{
	  if(options.Capitalise)
		text.Capitalise();
	  if(options.RemovePunctuation)
		text.RemovePunctuation();
	  if(options.Replace)
		text.Replace(options.ReplaceChar, options.ReplacementChar);
	  var split = text.Split(options.SplitChar);
	  string.Join(options.JoinChar, split);
	}
