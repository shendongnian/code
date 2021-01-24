void Main()
{
	const String input = 
@"Fn.If(first condition)
   When the first condition is valid! This is a required section
Fn.ElseIf(some second condition)
   When the second condition is valid! This is an optional section
Fn.ElseIf(third second condition)
   When the third condition is valid! This is an optional section
Fn.Else
    Catch all! This is an optional section
Fn.End	
	";
	
	Regex rIf     = new Regex( @"^Fn\.If\((.+)\)\s*$" );
	Regex rElseIf = new Regex( @"^Fn\.ElseIf\((.+)\)\s*$" );
	Regex rElse   = new Regex( @"^Fn\.Else\s*$" );
	Regex rEnd    = new Regex( @"^Fn\.End\s*$" );
	
	String[] lines = input.Split(new String[] { "\r\n" }, StringSplitOptions.None );
	
	List<Statement> statements = new List<Statement>();
	
	String type = null;
	String condition = null;
	StringBuilder sb = new StringBuilder();
	
	State state = State.Outside;
	foreach( String line in lines )
	{
		switch( state )
		{
		case State.Outside:
		
			Match mIf = rIf.Match( line );
			if( mIf.Success )
			{
				type = "Fn.If";
				condition = mIf.Groups[1].Value;
				
				state = State.InIf;
			}
		
			break;
		case State.InIf:
		case State.InElseIf:
		
			Match mElseIf = rElseIf.Match( line );
			if( mElseIf.Success )
			{
				statements.Add( new Statement( type, condition, sb.ToString() ) );
				sb.Length = 0;
				
				state = State.InElseIf;
				type = "Fn.ElseIf";
				condition = mElseIf.Groups[1].Value;
			}
			else
			{
				Match mElse = rElse.Match( line );
				if( mElse.Success )
				{
					statements.Add(new Statement(type, condition, sb.ToString()));
					sb.Length = 0;
					
					state = State.InElse;
					type = "Fn.Else";
					condition = null;
				}
				else
				{
					sb.Append( line );
				}
			}
		
			break;
		
		case State.InElse:
			Match mEnd = rEnd.Match(line);
			if (mEnd.Success)
			{
				statements.Add(new Statement(type, condition, sb.ToString()));
				sb.Length = 0;
				state = State.Outside;
				type = null;
				condition = null;
			}
			else
			{
				sb.Append( line );
			}
			break;
		}
	}
	
	statements.Dump();
}
class Statement
{
	public Statement( String type, String condition, String contents )
	{
		this.Type = type;
		this.Condition = condition;
		this.Contents = contents;
	}
	
	public String Type { get; }
	public String Condition { get; }
	public String Contents { get; }
}
// Define other methods and classes here
enum State
{
	Outside,
	InIf,
	InElseIf,
	InElse
}
Running in Linqpad gives me this output:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/uXyrV.png
