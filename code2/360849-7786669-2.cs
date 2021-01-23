    public class FaceBookReader : XmlTextReader
    {
        public FaceBookReader(Stream stream)
            : base(stream) { }
        public FaceBookReader(String url)
            : base(url) { }
        public override void ReadEndElement()
        {
            string elementTag = this.LocalName.ToLower();
            base.ReadEndElement();
            // When we've read the channel End Tag, we're going to skip all tags
            // until we reach the a new Ending Tag which should be that of rss
            if (elementTag == "channel")
            {
                while (base.IsStartElement())
                {
                    base.Skip();
                }
            }
        }
    }
