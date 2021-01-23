    string input = "10:name1*20:name2*30:name3*40:name4*50:name5";
    
    var data =
    (
    	from pair in input.Split( '*' )
    	let student = pair.Split( ':' )
    	select new { Grade = int.Parse( student[ 0 ] ), Name = student[ 1 ] }
    );
    
    foreach( var student in data )
    {
    	Console.WriteLine( student );
    }
