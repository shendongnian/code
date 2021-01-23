	public class XmlTextTransformWriter : System.Xml.XmlTextWriter
	{
		public XmlTextTransformWriter(System.IO.TextWriter w) : base(w) { }
		public XmlTextTransformWriter(string filename, System.Text.Encoding encoding) : base(filename, encoding) { }
		public XmlTextTransformWriter(System.IO.Stream w, System.Text.Encoding encoding) : base(w, encoding) { }
		public Func<string, string> TextTransform = s => s;
		public override void WriteString(string text)
		{
			base.WriteString(TextTransform(text));
		}
		public override void WriteCData(string text)
		{
			base.WriteCData(TextTransform(text));
		}
		public override void WriteComment(string text)
		{
			base.WriteComment(TextTransform(text));
		}
		public override void WriteRaw(string data)
		{
			base.WriteRaw(TextTransform(data));
		}
		public override void WriteValue(string value)
		{
			base.WriteValue(TextTransform(value));
		}
	}
