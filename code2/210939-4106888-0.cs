public class SamlSignedXml : SignedXml
    {
        private string _referenceAttributeId = "";
        public SamlSignedXml(XmlElement element, string referenceAttributeId)
            : base(element)
        {
            _referenceAttributeId = referenceAttributeId;
        }
        public override XmlElement GetIdElement(
            XmlDocument document, string idValue)
        {
            return (XmlElement)
                document.SelectSingleNode(
                    string.Format("//*[@{0}='{1}']",
                    _referenceAttributeId, idValue));
        }
    }
