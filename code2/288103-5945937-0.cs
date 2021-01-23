	void Main()
	{
		XElement thing = new XElement("test",  new XElement("child") );
		XElement otherThing = new XElement("test",  new XElement("child") );
		
		var comparer = new XElementComparer();
		var areSame = comparer.Equals(thing, otherThing);
		
		Console.WriteLine(areSame);
	}
	
	class XElementComparer : IEqualityComparer<XElement>
	{
		public bool Equals(XElement first, XElement second)
		{
			if (first.Name != second.Name)
				return false;
			else if (!first.Elements().SequenceEqual(second.Elements(), this))
				return false;
			else
				return true;
		}
		
		public int GetHashCode(XElement element) { return element.GetHashCode(); }
	}
