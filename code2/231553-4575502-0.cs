    internal class Inner
    {
        public int Number { get; set; }
        public string NotNumber { get; set; }
    }
    internal class Outer
    {
        public int ID { get; set; }
        public Dictionary<string, Inner> Dict { get; set; }
    }
    internal class Program
    {
        private static void Main()
        {
            var data = new Outer
                           {
                               ID = 1,
                               Dict =
                                   new Dictionary<string, Inner>
                                       {
                                           {
                                               "ABC",
                                               new Inner
                                                   {
                                                       Number = 1,
                                                       NotNumber = "ABC1"
                                                   }
                                               },
                                           {
                                               "DEF",
                                               new Inner
                                                   {
                                                       Number = 2,
                                                       NotNumber = "DEF2"
                                                   }
                                               }
                                       }
                           };
            var serialized =
                new XDocument(new XElement("Outer",
                                           new XAttribute("id", data.ID),
                                           new XElement("Dict",
                                                        from i in data.Dict
                                                        select
                                                            new XElement(
                                                            "Entry",
                                                            new XAttribute(
                                                                "key", i.Key),
                                                            new XAttribute(
                                                                "number",
                                                                i.Value.Number),
                                                            new XAttribute(
                                                                "notNumber",
                                                                i.Value.
                                                                    NotNumber)))));
            Console.WriteLine(serialized);
            Console.Write("ENTER to finish: ");
            Console.ReadLine();
        }
    }
