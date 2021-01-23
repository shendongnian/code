    private static List<CarriageReturn> _GetCarriageReturns( string data )
		{
			var carriageReturns = new List<CarriageReturn>();
			var carriageReturnRegex = new Regex( @"(?:([\n]+?))", RegexOptions.IgnoreCase | RegexOptions.Singleline );
			var carriageReturnMatches = carriageReturnRegex.Matches( data );
			if( carriageReturnMatches.Count > 0 )
			{
				carriageReturns.AddRange( carriageReturnMatches.Cast<Match>().Select( match => new CarriageReturn
				{
					Index = match.Groups[1].Index,
				} ).ToList() );
			}
			return carriageReturns;
		}
