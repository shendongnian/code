    public class Point 
    {
        public string Name { get; set; }
        public int Pressure { get; set; }
    
        public IEnumerable<Fraction> Fractions { get; set; }
    }
    
    public class Fraction
    {
        public string Id { get; set; }
        public double Value { get; set; }
    }
    
    static void Main()
    {
        string xml = @"<Points>
            <Point name='P1' pressure='1'>
                <Fractions>
                    <Fraction id='aaa' value='0.15272159'/>
                    <Fraction id='bbb' value='0.15272159'/>
                </Fractions>
            </Point>
            </Points>";
    
        XDocument doc = XDocument.Parse(xml);
        IEnumerable<Point> result = from c in doc.Descendants("Point")
                                    select new Point()
                                    {
                                        Name = (string)c.Attribute("name"),
                                        Pressure = (int)c.Attribute("pressure"),
                                        Fractions = from f in c.Descendants("Fraction")
                                                    select new Fraction() 
                                                    {
                                                        Id = (string)f.Attribute("id"),
                                                        Value = (double)f.Attribute("value"),
                                                    }
                                    };
    }
