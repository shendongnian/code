    private static string AssemblyProductVersion
    {
        get
        {
            object[] attributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);
            return attributes.Length == 0 ?
                "" :
                ((AssemblyInformationalVersionAttribute)attributes[0]).InformationalVersion;
        }
    }
