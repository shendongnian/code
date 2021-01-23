    string str = ":My name is Joe";
	
    var result = str.Where(c => char.IsLetter(c)).
            	     GroupBy(c => char.ToLower(c)).
		             Select(gr => new { Character = gr.Key, Count = gr.Count()}).
                     ToList();
 
