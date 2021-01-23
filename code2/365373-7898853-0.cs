    var builder = new ConfigurationSourceBuilder();
    
    builder.ConfigureLogging()
           .WithOptions
             .DoNotRevertImpersonation()
           .LogToCategoryNamed("My Category")
             .SendTo.FlatFile("MyMessages")
               .FormatWith(new FormatterBuilder()
                 .TextFormatterNamed("Text Formatter")
                   .UsingTemplate("Timestamp: {timestamp}...{newline})}"))
                 .ToFile("c:\\messages.log");
        
    var configSource = new DictionaryConfigurationSource();
    builder.UpdateConfigurationWithReplace(configSource);
    EnterpriseLibraryContainer.Current 
      = EnterpriseLibraryContainer.CreateDefaultContainer(configSource);
