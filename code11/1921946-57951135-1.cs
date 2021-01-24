           namesInXML.ForEach(name =>
            {
                if (!subFolderNames.Contains(name))
                {
                    settingsFile.Descendants("Items").Elements("Settings").
                    Where(x => x.Attribute(nameSpace + "type").Value == "FileModel" && x.Element("Name").Value.Equals(name)).
                    First().Remove();
                }
            });
