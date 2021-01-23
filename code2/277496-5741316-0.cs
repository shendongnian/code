         [Test]   
         public void TestLoggingWithFluentConfigurationAPI()   
         {  
             var builder = new ConfigurationSourceBuilder();   
             builder.ConfigureLogging()  
                 .WithOptions  
                 .DoNotRevertImpersonation()  
                 .LogToCategoryNamed("Basic")  
                 .SendTo.FlatFile("Basic Log File")  
                 .FormatWith(new FormatterBuilder()  
                                 .TextFormatterNamed("Text Formatter")  
                                 .UsingTemplate(  
                                     "Timestamp: {timestamp}{newline Message: {message}{newline}Category: {category}{newline}"))  
                 .ToFile("d:\\logs\\BasicTest.log") 
                 .SendTo.RollingFile("Rolling Log files") 
                 .RollAfterSize(1024)  
                 .ToFile("d:\\logs\\RollingTest.log")  
                  .LogToCategoryNamed("General")  
          .WithOptions.SetAsDefaultCategory()  
          .SendTo.SharedListenerNamed("Basic Log File");  
    
             var configSource = new DictionaryConfigurationSource(); 
             builder.UpdateConfigurationWithReplace(configSource);  
    
             EnterpriseLibraryContainer.Current  
               = EnterpriseLibraryContainer.CreateDefaultContainer(configSource); 
             LogWriterFactory logFactory = new LogWriterFactory(configSource);  
             LogWriter logWriter = logFactory.CreateDefault();  
             logWriter.Write("This is test message", "Basic");  
             logWriter.Write("This is default message");  
   
             string logfilepath = Path.Combine("d:", "logs\\BasicTest.log");  
             Assert.IsTrue(File.Exists(logfilepath)); 
             Assert.IsTrue(File.Exists("d:\\logs\\RollingTest.log"));
   
         }
