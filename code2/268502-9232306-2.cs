    public class RootlessDataSetXmlWriter : ElementSkippingXmlWriter
    {
        private string _dataSetName;
    
        public RootlessDataSetXmlWriter(Stream stream, string dataSetName)
            : base(stream, (e) => string.Equals(e, dataSetName, StringComparison.OrdinalIgnoreCase))
        {
            _dataSetName = dataSetName;
            this.Formatting = System.Xml.Formatting.Indented;
        }
    }
    
    public class ElementSkippingXmlWriter : XmlTextWriter
    {
        private Predicate<string> _elementFilter;
        private int _currentElementDepth;
        private Stack<int> _sightedElementDepths;
    
        public ElementSkippingXmlWriter(Stream stream, Predicate<string> elementFilter)
            : base(stream, Encoding.UTF8)
        {
            _elementFilter = elementFilter;
            _sightedElementDepths = new Stack<int>();
        }
    
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            if (_elementFilter(localName))
            {
                // Skip the root elements
                _sightedElementDepths.Push(_currentElementDepth);
            }
            else
            {
                base.WriteStartElement(prefix, localName, ns);
            }
    
            _currentElementDepth++;
        }
    
        public override void WriteEndElement()
        {
            _currentElementDepth--;
    
            if (_sightedElementDepths.Count > 0 && _sightedElementDepths.Peek() == _currentElementDepth)
            {
                _sightedElementDepths.Pop();
                return;
            }
    
            base.WriteEndElement();
        }
    }
