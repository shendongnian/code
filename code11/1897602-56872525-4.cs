    // className either in short format: "Form" or
    //                  in full  format: "System.Windows.Forms.Form"
    private static Type TypeFromName(string className)
    {
      if (string.IsNullOrWhiteSpace(className))
        return null;
      return AppDomain
        .CurrentDomain
        .GetAssemblies()
        .SelectMany(asm => asm.GetTypes())
        .FirstOrDefault(t => t.Name == className || t.Namespace + "." + t.Name == className);
    }
