     static void Main(string[] args)
        {
            string xmlFilePath = @"C:\Users\vincenzo.lanera\Desktop\test.xml";
            XmlDocument document = new XmlDocument();
            document.Load(xmlFilePath);
            Console.WriteLine("Inserisci l'elemento chimico da modificare:");
            var chimical = Console.ReadLine();
            
            //Searches the limit values of the selected element
            XmlNodeList limitValues = document.SelectNodes($"//ControlItem[@Name='{chimical}']/LimitValue");
            //Prints all limit values
            Console.WriteLine($"Limit values of {chimical}:");
            foreach (XmlNode limVal in limitValues)
            {
                Console.WriteLine($"{limVal.Attributes["Type"].Value} {limVal.InnerText}");
            };
            //Ask the user wich limit value wants to edit
            Console.WriteLine("Inserisci il limit value da modificare:");
            var limitValueToEdit = Console.ReadLine();
            //Ask the user the new value
            Console.WriteLine("Inserisci il nuovo valore:");
            var newVal = Console.ReadLine();
            //Edit the limit value
            var nodeToEdit = document.SelectSingleNode($"//ControlItem[@Name='{chimical}']/LimitValue[@Type='{limitValueToEdit}']");
            nodeToEdit.InnerText = newVal;
            //Save the changes to the xml file
            document.Save(xmlFilePath);
        }
    }
