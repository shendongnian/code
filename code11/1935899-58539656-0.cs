            List<object> allDirectoriesList = new List<object>();
            using (var reader = new StringReader(File.ReadAllText("./FileConfig.yml")))
            {
                allDirectoriesList = new DeserializerBuilder().Build().Deserialize<dynamic>(reader)["Directories"] as List<object>;
            }
            foreach (var directory in allDirectoriesList)
            {
                var directoryAsDictionary = (Dictionary<object, object>)directory;
                List<object> list = directoryAsDictionary.SelectMany(kvp => (List<object>)kvp.Value).ToList();
                List<string> _fileList = list.Select(Convert.ToString).ToList();
                foreach(var file in _fileList)
                    Console.WriteLine($"Item: {file} found in {Convert.ToString(directoryAsDictionary.Keys.First())}");
            }
