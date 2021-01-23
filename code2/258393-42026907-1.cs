    public static class Parameters
    {
        // For a Web Application
        public static string PathConfig { get; private set; } =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "web.config");
        // For a Class Library
        public static string PathConfig { get; private set; } =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "LibraryName.dll.config");
        public static string getParameter(string paramName)
        {
            string paramValue = string.Empty;
            using (Stream stream = File.OpenRead(PathConfig))
            {
                XDocument xdoc = XDocument.Load(stream);
                XElement element = xdoc.Element("configuration").Element("appSettings").Elements().First(a => a.Attribute("key").Value == paramName);
                paramValue = element.Attribute("value").Value;
            }
            return paramValue;
        }
    }
