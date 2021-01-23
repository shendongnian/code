    static void Main()
    {
    	Console.WriteLine(
    		(
    			from line in Generate(()=>Console.ReadLine()).Take(3)
    			let val = ParseAsInt(line)
    			where val.HasValue
    			select val.Value
    		).Min()
    	);
    }
    static IEnumerable<T> Generate<T>(Func<T> generator) { 
       while(true) yield return generator(); 
    }
    static int? ParseAsInt(string str) {
       int retval; 
       return int.TryParse(str,out retval) ? retval : default(int?); 
    }
