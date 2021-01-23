    public interface IXmlWritable
    {
        string ToXml();
    }
    public class Instrument : IXmlWritable
    {
        public string classification { get; set; }
        public string ToXml()
        {
            return "<Instrument classification='" + classification + "' />";
        }
    }
