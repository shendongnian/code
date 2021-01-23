     Type t = typeof(SomeClassInLanguageAssembly);
     Assembly languageAssembly = t.Assembly;
     Console.WriteLine("Current UI culture: "+Thread.CurrentThread.CurrentUICulture);
     Console.WriteLine("Resources in assembly:");
     languageAssembly.GetManifestResourceNames().ForEach(Console.WriteLine);
     ResourceManager r = new ResourceManager("Language.Assembly.Namespace.ResourceName", languageAssembly);
     Console.WriteLine("'YES' -> " + r.GetString("YES"));
