c#
private bool IsConfigurationFileValid
        {
            get
            {
                var assemblies = _configurationParameters.MappingAssemblies
                    .Where(mapAssembly => !string.IsNullOrEmpty(mapAssembly.Location))
                    .ToList();
                if (assemblies.Count == 0)
                {
                    return false;
                }
                var serializedConfigFileInfo = new FileInfo(SerializedConfigurationFilePath);
                return assemblies
                    .Select(mapAssembly => new FileInfo(mapAssembly.Location))
                    .Aggregate(true, (current, mapAssembly) => current & (mapAssembly.CreationTime <= serializedConfigFileInfo.CreationTime && mapAssembly.LastWriteTime <= serializedConfigFileInfo.LastWriteTime));
            }
        }
        private void SaveConfigurationToFile(NHibernate.Cfg.Configuration configuration)
        {
            try
            {
                using (var file = File.Open(SerializedConfigurationFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    var bf = new BinaryFormatter();
                    bf.Serialize(file, configuration);
                }
            }
            catch (Exception e)
            {
                _log.Fatal("Cant save serialized configuration", e);
            }
        }
        private NHibernate.Cfg.Configuration LoadConfigurationFromFile()
        {
            if (!IsConfigurationFileValid)
                return null;
            try
            {
                using (var file = File.Open(SerializedConfigurationFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var bf = new BinaryFormatter();
                    var configurationFromFile = bf.Deserialize(file) as NHibernate.Cfg.Configuration;
                    if (configurationFromFile == null)
                        return null;
                    var currentConnectionString = configurationFromFile.GetProperty(NHibernate.Cfg.Environment.ConnectionString);
                    return currentConnectionString == _configurationParameters.ConnectionString
                        ? configurationFromFile
                        : null;
                }
            }
            catch (Exception ex)
            {
                _log.Info("LoadConfigurationFromFile failed", ex);
                return null;
            }
        }
