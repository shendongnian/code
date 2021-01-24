    try this:
     //string chemForm = "HHO"; // H2 O1
     string chemForm = "CH4N10"; // C1 H4 N10
     var distinctElements = new HashSet<char>();
     var KVPs = new Dictionary<char, int>();
            
    chemForm
    .ToUpper()
    .ToCharArray()
    .Where(c => Regex.Match(c.ToString(), @"[A-Z]").Success)
    .ToList()
    .ForEach(c => distinctElements.Add(c));
    foreach (char c in distinctElements)
    {
	   Match m = Regex.Match(chemForm,
       $@"(?<element>[{c}]+(?=\D|\b))|(?<quantifiedElement>[{c}][0-9]+)");
	    if (!string.IsNullOrEmpty(m.Groups["element"].Value)) KVPs.Add(c, 
       m.Groups["element"].Value.Length);
	    if (!string.IsNullOrEmpty(m.Groups["quantifiedElement"].Value)) KVPs.Add(c, 
      int.Parse(m.Groups["quantifiedElement"].Value.Substring(1)));
    }
    KVPs.Dump();
