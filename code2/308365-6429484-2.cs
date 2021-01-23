    string input = "10:name1.1*name1.2*name1.3,20:name2.1*name2.2*,30:name3.1,40:name4.1*name4.2*name4.3,50:name5.1";
    
    var studentData = ( Lookup<int,string[]> )
    (
    	from 
    		line in input.Split( ',' )
    	let 
    		grade = line.Substring( 0, line.IndexOf( ':' ) )
    	let 
    		names = line.Remove( 0, grade.Length + 1 ).Split( '*' )
    	select 
    		new { Grade = int.Parse( grade ), Students = names }
    ).ToLookup( s => s.Grade, s => s.Students );
    
    foreach( IGrouping<int,string[]> gradeSet in studentData )
    {
    	Console.WriteLine( gradeSet.Key );
    	Console.WriteLine( studentData[ gradeSet.Key ] );
    }
