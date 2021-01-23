    	public class Stream
    	{
    		public StringBuilder StringBuilder { get; set; }
    		public Stream(StringBuilder stringBuilder) { StringBuilder = stringBuilder; }
    		public Formatter Formatter = new Formatter("{0}");
    		public Stream Serialize(object o)
    		{
    			var formatter = o as Formatter;
    			if (formatter != null) Formatter = formatter;
    			else StringBuilder.Append(Formatter.Format((o ?? "").ToString())).Append(";");
    			return this;
    		}
    	}
    
    	public class Formatter
    	{
    		public string FormatString { get; set; }
    		public Formatter(string s) { FormatString = s; }
    		public string Format(string s) { return string.Format(FormatString, s); }
    	}
    
    	public class StreamMemento : IDisposable
    	{
    		private Stream Originator { get; set; }
    		private Formatter FormatterBefore { get; set; }
    		public StreamMemento(Stream s) { Originator = s; FormatterBefore= s.Formatter; }
    		public void Dispose() { Originator.Formatter = FormatterBefore; }
    	}
