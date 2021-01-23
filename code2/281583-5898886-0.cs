    public static class ConnectionManager
    {
        public static string GetConnectionString(string modelName)
        {
            var resourceAssembly = Assembly.GetCallingAssembly();
            var resources = resourceAssembly.GetManifestResourceNames();
            if (!resources.Contains(modelName + ".csdl")
                || !resources.Contains(modelName + ".ssdl")
                || !resources.Contains(modelName + ".msl"))
            {
                throw new ApplicationException(
                        "Could not find connection resources required by assembly: "
                        + System.Reflection.Assembly.GetCallingAssembly().FullName);
            }
            var provider = System.Configuration.ConfigurationManager.AppSettings.Get(
                            "MyModelUnitOfWorkProvider");
            var providerConnectionString = System.Configuration.ConfigurationManager.AppSettings.Get(
                            "MyModelUnitOfWorkConnectionString");
            string ssdlText;
            using (var ssdlInput = resourceAssembly.GetManifestResourceStream(modelName + ".ssdl"))
            {
                using (var textReader = new StreamReader(ssdlInput))
                {
                    ssdlText = textReader.ReadToEnd();
                }
            }
            var token = "Provider=\"";
            var start = ssdlText.IndexOf(token);
            var end = ssdlText.IndexOf('"', start + token.Length);
            var oldProvider = ssdlText.Substring(start, end + 1 - start);
            ssdlText = ssdlText.Replace(oldProvider, "Provider=\"" + provider + "\"");
            var tempDir = Environment.GetEnvironmentVariable("TEMP") + '\\' + resourceAssembly.GetName().Name;
            Directory.CreateDirectory(tempDir);
            var ssdlOutputPath = tempDir + '\\' + Guid.NewGuid() + ".ssdl";
            using (var outputFile = new FileStream(ssdlOutputPath, FileMode.Create))
            {
                using (var outputStream = new StreamWriter(outputFile))
                {
                    outputStream.Write(ssdlText);
                }
            }
            var eBuilder = new EntityConnectionStringBuilder
            {
                Provider = provider,
                Metadata = "res://*/" + modelName + ".csdl"
                            + "|" + ssdlOutputPath
                            + "|res://*/" + modelName + ".msl",
                ProviderConnectionString = providerConnectionString
            };
            return eBuilder.ToString();
        }
    }
