    Namespace: using System.IO;  
     
    string filelocation = Properties.Settings.Default.Filelocation;
    string[] filesname = Directory.GetFiles(filelocation); //for multiple files
        
    Your path configuration in App.config file-
        
        <userSettings>
            <ConsoleApplication13.Properties.Settings>
              <setting name="Filelocation" serializeAs="String">
                <value>D:\\DeleteFileTest</value>
              </setting>
                  </ConsoleApplication13.Properties.Settings>
          </userSettings>
