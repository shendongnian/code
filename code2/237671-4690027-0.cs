     BooleanQuery rootQuery = new ...
     PhraseQuery q1 = new PhraseQuery("A Level");
     TermQuery q2 = new TermQuery("English");
     TermQuery q3 = new TermQuery("Maths");
     TermQuery q4 = new TermQuery("Physics");
     rootQuery.Add(q1, BooleanClause.Occur.SHOULD); //or MUST - depends on you
     rootQuery.Add(q2, BooleanClause.Occur.SHOULD); 
     rootQuery.Add(q3, BooleanClause.Occur.SHOULD); 
     rootQuery.Add(q4, BooleanClause.Occur.SHOULD); 
