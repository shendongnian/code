    private static string GetFamilyFromResource(string resourceName)
        {
            var contents = Resources.StreamBinaryEmbeddedResource(AppCommand.AppInstance.Assembly,
                $"FullPathToResource.{resourceName}.rfa");
            if (!contents.Any()) return string.Empty;
        
            var filePath = Path.Combine(Path.GetTempPath(), $"{resourceName}.rfa");
        
            using (var fileStream = File.Open(filePath, FileMode.Create))
            using (var writer = new BinaryWriter(fileStream))
            {
                writer.Write(contents);
            }
        
            if (!File.Exists(filePath) || new FileInfo(filePath).Length <= 0) return string.Empty;
        
            return filePath;
        }
        
            public static byte[] StreamBinaryEmbeddedResource(Assembly assembly, string fileName)
            {
                using (var stream = assembly.GetManifestResourceStream(fileName))
                {
                    if (stream == null) return new byte[] { };
        
                    var buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, (int)stream.Length);
                    stream.Dispose();
                    return buffer;
                }
            }
