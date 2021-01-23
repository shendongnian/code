	public class XmlRemoveInvalidCharacterWriter : XmlTextTransformWriter
	{
		public XmlRemoveInvalidCharacterWriter(System.IO.TextWriter w) : base(w) { SetTransform(); }
		public XmlRemoveInvalidCharacterWriter(string filename, System.Text.Encoding encoding) : base(filename, encoding) { SetTransform(); }
		public XmlRemoveInvalidCharacterWriter(System.IO.Stream w, System.Text.Encoding encoding) : base(w, encoding) { SetTransform(); }
		void SetTransform()
		{
			TextTransform = XmlUtil.RemoveInvalidXmlChars;
		}
	}
