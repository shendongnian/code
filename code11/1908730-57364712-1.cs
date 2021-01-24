	var str =
		"[QUOTE=harris]\n" +
		"  <p>This is quote by Harris</p>\n" +
		"  [QUOTE=marshal]\n" +
		"    <p>This is quote by Marshal</p>\n" +
		"    [QUOTE=Ted] <p>This is quote by Ted</p>[/QUOTE]\n" +
		"    <p>This is DUP quote by Marshal</p>[/QUOTE]\n" +
		"  <p>This is DUP quote by Harris</p>\n" +
		"[/QUOTE]\n";
	var rx = new Regex(@"(?s)(?>\s*(?'Quote'\[QUOTE=(.*?)\])\s*((?:(?!\[/?QUOTE).)*)\s*|\s*((?:(?!\[/?QUOTE).)*)\s*(?'-Quote'\[/QUOTE\])\s*)+(?(Quote)(?!))");
	Match M = rx.Match(str);
	if (M.Success)
	{
		CaptureCollection ccNames = M.Groups[1].Captures;  // Names
		CaptureCollection ccPre = M.Groups[2].Captures;    // Pre body
		CaptureCollection ccPost = M.Groups[3].Captures;   // Post body
		Console.WriteLine("Match = {0}", M.ToString());
		int cnt = ccNames.Count;
		String sDiv = "<div class=\"blockquote\">";
		String htmlOut = "";
		String sTab = "";
		for (int i = 0; i < cnt; i++)
		{
			String name = ccNames[i].Value.Trim();
			String Pre = ccPre[i].Value.Trim();
			String Post = ccPost[cnt - i - 1].Value.Trim();
			Console.WriteLine("{0} Name {1}", i, name);
			Console.WriteLine("\t{0} Pre {1}", i, Pre);
			Console.WriteLine("\t{0} Post {1}", cnt-i-1, Post);
			// Format output
			htmlOut += "\n" + sTab + sDiv + "\n";
			
			sTab += "\t";
			htmlOut += sTab + "<small>Posted by " +name + "</small>";
			String scratch = "";
			if ( Pre.Length > 0)
				scratch += "\n" + sTab + Pre;
			if ( Post.Length > 0)
				scratch += "\n" + sTab + Post;
			htmlOut += scratch;
		}
		
		for (int i = 0; i < cnt; i++)
		{
			sTab = "";
			for ( int k = 0; k < (cnt-i-1); k++ )
				sTab += "\t";
			htmlOut += "\n" + sTab + "</div>";
		}
		Console.WriteLine("------------------");
		Console.WriteLine("{0}", htmlOut);
	}
