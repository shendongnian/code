    public class EmbeddedResources
    {
        private bool isUnpacked = false;
    
        public async Task EnsureUnpacked(string saveDirectory)
        {
            if (!this.isUnpacked)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var assemblyDirectory = Path.GetDirectoryName(assembly.Location);
                foreach (var name in assembly.GetManifestResourceNames())
                {
                    var stream = assembly.GetManifestResourceStream(name);
    
                    var stringBuilder = new StringBuilder();
                    var parts = name
                        .Replace(typeof(EmbeddedResources).Namespace + ".", string.Empty)
                        .Split('.')
                        .ToList();
                    for (int i = 0; i < parts.Count; ++i)
                    {
                        var part = parts[i];
                        if (string.Equals(part, string.Empty))
                        {
                            stringBuilder.Append(".");      // Append '.' in file name.
                        }
                        else if (i == parts.Count - 2)
                        {
                            stringBuilder.Append(part);     // Append file name and '.'.
                            stringBuilder.Append('.');
                        }
                        else if (i == parts.Count - 1)
                        {
                            stringBuilder.Append(part);     // Append file extension.
                        }
                        else
                        {
                            stringBuilder.Append(part);     // Append file path.
                            stringBuilder.Append('\\');
                        }
                    }
    
                    var filePath = Path.Combine(saveDirectory, stringBuilder.ToString());
                    using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }
    
                this.isUnpacked = true;
            }
        }
    }
