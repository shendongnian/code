    class Program
        {
            static void Main(string[] args)
            {
                var xml = "<div class=\"time\">" +
                            "<span class=\"title\">Bla: </span>" +
                            "<span class=\"value\">Thu 20 Jan 11</span>" +
                            "</div>";
                var document = new XmlDocument();
    
                try
                {
                    document.LoadXml(xml);
                }
                catch (XmlException xe)
                {
                    // Handle and/or re-throw
                    throw;
                }
    
                var date = document.SelectSingleNode("//span[@class = 'value']").InnerText;
    
                Console.WriteLine(date);
    
                Console.ReadKey();
            }
        }
