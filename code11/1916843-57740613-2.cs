    var vcards = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "Contacts.vcf"));
    
    var vcardRe = new Regex(@"BEGIN:VCARD\s+(.+?)\s+END:VCARD", RegexOptions.Compiled | RegexOptions.Singleline);
    
    
    var res = vcardRe.Matches(vcards)
    .Cast<Match>()
    .Select(x => x.Groups[0].Captures.Cast<Capture>().Select(c => c.Value).Last())
    ;
    
    List<Thought.vCards.vCard> vCards = new List<Thought.vCards.vCard>();
    
    List<string> failedStrings = new List<string>();
    
    foreach(string card in res)
    {
    	using (TextReader sr = new StringReader(card))
    	{
    		var vCard = new Thought.vCards.vCard(sr);
    
    		if (vCard == null)
    		{
    			failedStrings.Add(card);
    			continue;
    		}
    
    		vCards.Add(vCard);
    	}
    }
    
    vCards.Dump();
