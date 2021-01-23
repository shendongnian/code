    <!-- language: c# -->
    private static string wmiProperty(string wmiClass, string wmiProperty){
      using (var searcher = new ManagementObjectSearcher($"SELECT * FROM {wmiClass}")) {
       try {
                        IEnumerable<ManagementObject> objects = searcher.Get().Cast<ManagementObject>();
                        return objects.Select(x => x.GetPropertyValue(wmiProperty)).FirstOrDefault().ToString().Trim();
                    } catch (NullReferenceException) {
                        return null;
                    }
                }
            }
