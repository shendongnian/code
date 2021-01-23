    class Nully
    {
    	public static bool operator ==(Nully n, object o)
        {
    		Console.WriteLine("Comparing '" + n + "' with '" + o + "'");
    		return true;
    	}
    	public static bool operator !=(Nully n, object o) { return !(n==o); }
    }
    void Main()
    {
        var data = new Nully();
    	Console.WriteLine(null == data);
    	Console.WriteLine(object.ReferenceEquals(null, data));
    }
