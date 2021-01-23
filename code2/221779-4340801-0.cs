    void Main()
    {
    	var chars = new List<char>(); 
    	var strings = new List<string>(); 
    	
    	chars.AddRange(new char[] {'1','2','4','7','8','3'});
    	strings.AddRange(new string[] {"01","02","09","12","28","52"}); 
    
    	chars.Dump(); 
    	strings.Dump(); 
    	
    	Func<IList<object>, string> SelectFirst = ( list ) 
            => list.First().ToString();
    	Func<IList<object>, string> SelectLast = ( list ) 
            => list.Last().ToString();
    	Func<IList<object>, string> SelectRandom = ( list ) 
            => list.ElementAt( new Random().Next(0, list.Count())).ToString(); 
    	
    	SelectBy(SelectFirst, strings.Cast<object>().ToList()).Dump(); 
    	SelectBy(SelectFirst, chars.Cast<object>().ToList()).Dump(); 
    	
    	SelectBy(SelectLast, strings.Cast<object>().ToList()).Dump(); 
    	SelectBy(SelectLast, chars.Cast<object>().ToList()).Dump(); 
    	
    	SelectBy(SelectRandom, strings.Cast<object>().ToList()).Dump(); 
    	SelectBy(SelectRandom, chars.Cast<object>().ToList()).Dump(); 
    }
    
    private string SelectBy(Func<IList<object>, string> func, IList<object> list)
    {	
    	return func(list); 
    }
