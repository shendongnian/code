    AssemblyInformationalVersionAttribute attribute = 
       (AssemblyInformationalVersionAttribute)Assembly.GetExecutingAssembly()
       .GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false).FirstOrDefault();
    if (attribute != null)
         Console.WriteLine(attribute.InformationalVersion);
