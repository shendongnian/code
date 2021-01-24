    public static void Main()
    	{
    		List<string> names=new List<string>{"A","xxx","B","C","D","yyy","E","F"};
    		List<dynamic> dyn=new List<dynamic>();
    		dynamic person = new ExpandoObject();
    		person.Name="xxx";
    		person.Address="ADD";
    		dynamic person1 = new ExpandoObject();
    		person1.Name="yyy";
    		person1.Address="ADD";
    		dyn.Add(person);
    		dyn.Add(person1);
    		
    		var x=names.Where(p=>!dyn.Select(q=>q.Name).Contains(p)).ToList().Distinct().Take(5);
    		foreach(var n in x)
    		{
    			Console.WriteLine(n);
    		}
    	}
