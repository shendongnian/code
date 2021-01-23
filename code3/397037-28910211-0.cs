    public class Quotes{ 
        public string symbol; 
        public string extension
    }
	var values = new HashSet<Tuple<string,string>>();
	
	values.Add(new Tuple<string,string>("A","=n"));
	values.Add(new Tuple<string,string>("A","=n"));
	
    // values.Count() == 1
	values.Select (v => new Quotes{ symbol = v.Item1, extension = v.Item2 });
