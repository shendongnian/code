        public IEnumerable<object> GetAllInheritors(string interfaceName)
        {
            Assembly assembly = this.GetType().Assembly;
            foreach (var part in Container.Catalog.Parts)
            {
                Type type = assembly.GetType(part.ToString());
                if (type != null)
                    if (type.GetInterface(interfaceName) != null)
                    {
                        yield return part.CreatePart().GetExportedValue(part.ExportDefinitions.First());
                    }
            }
        }
