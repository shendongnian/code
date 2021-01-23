    string msg = "This is a small message !";
    string Input = "This is a small message !This is a small message !";
    
    System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(msg);
    System.Text.RegularExpressions.MatchCollection Matches = r.Matches(Input);
    
    int Count = Matches.Count; //Count = 2
