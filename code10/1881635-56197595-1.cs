    var list = Enumerable.Range(1, 100);
 	Func<int, bool> predicate = v => true; // start with true since we chain ANDs first
    predicate = predicate.And(v => v % 2 == 0); // numbers dividable by 2
    predicate = predicate.And(v => v % 3 == 0); // numbers dividable by 3
    predicate = predicate.Or(v => v % 31 == 0); // numbers dividable by 31
 
    var result = list.Where(v => predicate(v));
    
    foreach (var i in result)
    	Console.WriteLine(i);
    	
