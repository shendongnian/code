    HashSet<Tuple<string, string, string>> values = new HashSet<Tuple<string, string, string>>();
            var nodes = webservice.nepService.GetAllElementsOfElementType(webservice.ext, "Busbar", ref elementNames, ref elementTypes);
            foreach (var nodename in elementNames.Values)
            {
                var nodeRes = webservice.nepService.GetResultElementByName(webservice.ext, nodename, "Busbar", -1, "LoadFlow", null);
                var Uvolt = GetXMLAttribute(nodeRes, "U");
                var Upercentage = GetXMLAttribute(nodeRes, "Up");
                values.Add(Tuple.Create(nodename, Uvolt, Upercentage));
            } 
            
            var output = string.Join("\n", values.ToList().Select(tuple => $"{tuple.Item1},{tuple.Item2},{tuple.Item3}").ToList());
            string outputFile = @"C:\Users\12.csv";
            File.WriteAllText(outputFile, output); 
