    public static class DeterministicStreamStateExtensions
    {
    	public static Stream IsolatingState(
    		this Stream stream,
    		object formatter,
    		Func<Stream,Stream> map)
    	{
    		using(new DeterministicState(stream, formatter))
    			return map(stream);
    	}
    }
