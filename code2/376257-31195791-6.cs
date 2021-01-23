	public class XmlTextWriterIgnoreInvalidChars : XmlTextWriter
	{
		public bool DeleteInvalidChars { get; set; }
        public XmlTextWriterIgnoreInvalidChars(TextWriter w, bool deleteInvalidChars = true) : base(w)
		{
			DeleteInvalidChars = deleteInvalidChars;
		}
		public override void WriteString(string text)
		{
			if (text != null && DeleteInvalidChars)
				text = XML.ToValidXmlCharactersString(text);
			base.WriteString(text);
		}
	}
