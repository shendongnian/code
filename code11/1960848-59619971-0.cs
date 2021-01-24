csharp
class MyWriter : XmlTextWriter
{
	private int Top // this is a pointer to top of internal stack that XmlWriter uses to determine closing tag correspondence
	{
		get
		{
			FieldInfo top = typeof(XmlTextWriter).GetField("top", BindingFlags.NonPublic | BindingFlags.Instance);
			return (int)top.GetValue(this);
		}
	}
	
	public MyWriter(string name, Encoding enc) : base(name, enc) {}
	public override void WriteStartElement(string prefix, string localName, string ns)
	{
		if (localName == "NewDataSet") { // skip the tag
			MethodInfo PushStack = typeof(XmlTextWriter).GetMethod("PushStack", BindingFlags.NonPublic | BindingFlags.Instance);
			PushStack.Invoke(this, new object[] {}); // for internal state tracking to work, we still need to push the stack as if we wrote it out. we'll have to account for that later
			return;
		}
		
		base.WriteStartElement(prefix, localName, ns);
	}
	public override void WriteEndElement()
	{
		if(Top <= 1) return; // do not attempt to write outermost tag, we already skipped it in the opening counterpart
		base.WriteEndElement();
	}
}
void Main()
{
    //...your code here
	
	var writer = new MyWriter(@"C:\Test\Test.XML", Encoding.UTF8); // instantiate your own writerm
	ds.WriteXml(writer, XmlWriteMode.IgnoreSchema); // and use it instead of stock standard
}
as you can see, problem is, `XmlWriter` does not expose some methods and properties required for this to work, so I had to use reflection to invoke them. Moreover, it makes it extremely hard to fetch some data structures by keeping them internal to class (as an exercise, try fetching `TagInfo[] stack` field using the above technique and see what happens).
This however should give you the output you desire.
  [1]: https://stackoverflow.com/questions/4304038/do-you-always-have-to-have-a-root-node-with-xml-xsd
