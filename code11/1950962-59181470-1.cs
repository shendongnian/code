        private static TestClass setUpValues()
        {
            var Content = JsonConvert.DeserializeObject<deploy>(File.ReadAllText(path));
            List<Variable> variables = Content.Variables.ToList();
            Scopes Scope = Content.ScopeValues;
            string Version = null;
            List<string> ListOfSelectedItems = new List<string>();
            List<string> TempListOfSelectedItems = new List<string>();
            List<string> Channels = new List<string>();
            foreach (var item in variables)
            {
                if (item.Name.Equals("version"))
                {
                    Version = item.Value;
                }
                if (item.Name.Equals("Selected"))
                {
                    TempListOfSelectedItems.Add(item.Value);
                }
            }
            var retObj = new TestClass();
            Console.WriteLine("Version  " + Version);
            Console.WriteLine();
            retObj.Version = Version;
            string SelectedItems = TempListOfSelectedItems[0];
            ListOfSelectedItems = SelectedItems.Split(',').ToList();
            Console.WriteLine();
            Console.WriteLine("Selected Modules");
            Console.WriteLine();
            foreach (var item in ListOfSelectedItems)
            {
                Console.WriteLine(item);
                retObj.ListOfSelectedItems.Add(item);
            }
            foreach (var item in Scope.Channels)
            {
                Channels.Add(item.Name);
            }
            return retObj;
        }
