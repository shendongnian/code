    static void Main(string[] args)
        {
            var rawXml =
                @"<Data>
        <Cars>
          <Details>
            <Dataset se-datafilter=""cars"" dv-datamanipulationrequired=""false"" dv-filtercondition="""" dv-sortcolumn="""" dv-gettopNrows="""" />
            <XmlData></XmlData>
          </Details>
        </Cars>
        <Jeeps>
          <Details>
            <Dataset se-datafilter=""jeeps"" dv-datamanipulationrequired=""false"" dv-filtercondition="""" dv-sortcolumn="""" dv-gettopNrows="""" />
            <XmlData></XmlData>
          </Details>
        </Jeeps>
    </Data>
    ";
            var xDoc = XDocument.Parse(rawXml);
            var datasets = xDoc.Descendants("Dataset");
            var attrs1 = datasets.AttributesAt(0);
            foreach (var attr in attrs1)
            {
                Console.WriteLine(attr.Value);
            }
            var attrs2 = datasets.AttributesAt(1);
            foreach (var attr in attrs2)
            {
                Console.WriteLine(attr.Value);
            }
        }
    }
    public static class XExtensions
    {
        public static IEnumerable<XAttribute> AttributesAt(this IEnumerable<XElement> datasets, int index)
        {
            return datasets.ElementAt(index).Attributes();
        }
    }
