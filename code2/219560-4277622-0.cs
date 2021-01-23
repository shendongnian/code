    var splitstring = myHtmlString.Split('#');
    var tokens = new List<string>();
    for( int i = 1; i < splitstring.Length; i+=2){
      tokens.Add(splitstring[i]);
    }	
