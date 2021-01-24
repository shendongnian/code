    public class XmlNoBreakSpaceTextReader : XmlTextReader
    {
        public XmlNoBreakSpaceTextReader(TextReader reader) : base(reader) { }
		string overrideValue = null;
		XmlNodeType? overrideType = null;
		
		public override string Value { get { return overrideValue ?? base.Value; } }
		
		public override XmlNodeType NodeType { get { return overrideType ?? base.NodeType; } }
        public override bool Read()
        {
            overrideValue = null;
            overrideType = null;
            while (base.Read())
            {
                var nodeType = base.NodeType;
                if (nodeType == XmlNodeType.Text)
                {
                    var value = base.Value;
                    var newValue = value.Replace('\u00A0', '\n');
                    if ((object)newValue != (object)value)
                    {
                        var newNodeType = newValue.All(c => XmlConvert.IsWhitespaceChar(c)) ? XmlNodeType.Whitespace : nodeType;
                        if (newNodeType == XmlNodeType.Whitespace && WhitespaceHandling != WhitespaceHandling.All)
                            continue;
                        overrideValue = newValue;
                        overrideType = newNodeType;
                        return true;
                    }
                }
                return true;
            }
            return false;
        }
    }
