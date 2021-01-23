    // Note: names changed to follow conventions, and now a class
    // rather than a struct. Mutable structs are evil.
    public class ConceptWeight
    {
        public string Concept { get; set; }
        // Type changed to reflect the natural data type
        public double Weight { get; set; }
    }
    XNamespace ns = "http://www.domain.com/api";
    // No need to traverse the path all the way, unless there are other "concepts"
    // elements you want to ignore. Note the use of ns here.
    var list = d.Descendants(ns + "concepts")
                .Select(c => new ConceptWeight
                        {
                            Concept = (string) c.Attribute("label"),
                            Weight = (double) c.Attribute("weight"),
                        })
                .ToList();
