    class Program
    {
        static void Main(string[] args)
        {
            XElement main = XElement.Parse(
        @"<Users>
           <User>
                <Name>Alex</Name>
                <test>
                    <Date>08.05.2011</Date>
                    <points>4</points>
                </test>
            </User>
            <User>
                <Name>John Smith</Name>
                <test>
                    <Date>23.05.2011</Date>
                    <points>33</points>
                </test>
                <test>
                    <Date>22.06.2011</Date>
                    <points>29</points>
                </test>
            </User>
        </Users>");
        
        var users =
           from m in main.Elements("User")
           where (string)m.Element("Name") == "John Smith"
           select (m.Descendants("test").Descendants("Date").FirstOrDefault().Value);
        XElement Mercury = main.Elements("User").Where(p => (String)p.Element("Name") == "John Smith").FirstOrDefault();
        Mercury.Add(new XElement("test", new XElement("Date", "06.06.2011"), new XElement("points", "01")));
        foreach (var user in main.Elements())
            Console.WriteLine(user);
        Console.ReadLine();
    }
