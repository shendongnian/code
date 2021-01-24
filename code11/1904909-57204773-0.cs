        public class Limits
        {
            public string LowerWarningLimit = "";
            public string UpperWarningLimit = "";
            public string LowerAcceptanceLimit = "";
            public string UpperAcceptanceLimit = "";
        }
        public static void GetLimits(string nameFile)
        {
            XDocument document = XDocument.Load(nameFile);
            if (document == null)
            {
                Console.WriteLine("Document not found.");
                return;
            }
            XElement root = document.Descendants("ControlItems").FirstOrDefault();
            if (root == null)
            {
                Console.WriteLine("Could not find ControlItems.");
                return;
            }
            Console.WriteLine("Inserisci lelemento chimico da modificare:");
            var chimical = Console.ReadLine();
            XElement nameSearch = root.Descendants("ControlItem").FirstOrDefault(x => x.Attribute("Name") != null && x.Attribute("Name").Value.ToLower() == chimical.ToLower());
            if (nameSearch == null)
            {
                Console.WriteLine("Name not found.");
                return;
            }
            Limits limits = new Limits();
            foreach (XElement elements in nameSearch.Descendants())
            {
                string typeResult = elements.Attribute("Type").Value;
                if (typeResult == null)
                {
                    continue;
                }
                switch (typeResult)
                {
                    case "LowerWarningLimit":
                        limits.LowerWarningLimit = elements.Value;
                        break;
                    case "UpperWarningLimit":
                        limits.UpperWarningLimit = elements.Value;
                        break;
                    case "LowerAcceptanceLimit":
                        limits.LowerAcceptanceLimit = elements.Value;
                        break;
                    case "UpperAcceptanceLimit":
                        limits.UpperAcceptanceLimit = elements.Value;
                        break;
                }
            }
            Console.WriteLine(limits.LowerWarningLimit);
            Console.WriteLine(limits.UpperWarningLimit);
            Console.WriteLine(limits.LowerAcceptanceLimit);
            Console.WriteLine(limits.UpperAcceptanceLimit);
        }
