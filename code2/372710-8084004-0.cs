    public class KMLDocument
    {
        [XmlElement("Placemark", Type=typeof(Placemark)),
        XmlElement("Feature", Type=typeof(Feature))]
        public KMLObject[] members;
    }
