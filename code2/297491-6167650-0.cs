     public class UserSettingsManager
        {
            private IsolatedStorageFile isolatedStorage;
            private readonly String applicationDirectory;
            private readonly String settingsFilePath;
    
            public UserSettingsManager()
            {
                this.isolatedStorage = IsolatedStorageFile.GetMachineStoreForAssembly();
                this.applicationDirectory = "UserSettingsDirectory";
                this.settingsFilePath = String.Format("{0}\\settings.xml", this.applicationDirectory);
            }
    
            public Boolean WriteSettingsData(String content)
            {
                if (this.isolatedStorage == null)
                {
                    return false;
                }
    
                if (! this.isolatedStorage.DirectoryExists(this.applicationDirectory))
                {
                    this.isolatedStorage.CreateDirectory(this.applicationDirectory);
                }
    
                using (IsolatedStorageFileStream fileStream =
                    this.isolatedStorage.OpenFile(this.settingsFilePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
    
                    streamWriter.Write(content);
                }
    
                return true;
            }
    
            public String GetSettingsData()
            {
                if (this.isolatedStorage == null)
                {
                    return String.Empty;
                }
    
                using(IsolatedStorageFileStream fileStream =
                    this.isolatedStorage.OpenFile(this.settingsFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                using(StreamReader streamReader = new StreamReader(fileStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
