    public class CustomSignedXml : SignedXml
    {
        public CustomSignedXml(XmlDocument doc) : base(doc)
        {
            return;
        }
        public override XmlElement GetIdElement(XmlDocument doc, string id)
        {
            // see if this is the key info being referenced, otherwise fall back to default behavior
            if (String.Compare(id, this.KeyInfo.Id, StringComparison.OrdinalIgnoreCase) == 0)
                return this.KeyInfo.GetXml();
            else
                return base.GetIdElement(doc, id);
        }
    }
