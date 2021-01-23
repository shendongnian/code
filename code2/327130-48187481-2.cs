    Namespace: using System.IO;  
     //use this to get file name dynamically 
     string filelocation = Properties.Settings.Default.Filelocation;
    //use this to get file name statically 
    //string filelocation = @"D:\FileDirectory\";
    string[] filesname = Directory.GetFiles(filelocation); //for multiple files
        
    Your path configuration in App.config file if you are going to get file name dynamically  -
        
        <userSettings>
            <ConsoleApplication13.Properties.Settings>
              <setting name="Filelocation" serializeAs="String">
                <value>D:\\DeleteFileTest</value>
              </setting>
                  </ConsoleApplication13.Properties.Settings>
          </userSettings>
