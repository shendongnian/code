    public class PhoneSettings
    {
    	private const string SettingsDir = "settingsDir";
    	private const string SettingsFile = "settings.xml";
    
    	public void SetSettings(Settings settings)
    	{
    		SaveSettingToFile<Settings>(SettingsDir, SettingsFile, settings);
    	}
    
    	public Settings GetSettings()
    	{
    		return RetrieveSettingFromFile<Settings>(SettingsDir, SettingsFile);
    	}
    
    	private T RetrieveSettingFromFile<T>(string dir, string file) where T : class
    	{
    		IsolatedStorageFile isolatedFileStore = IsolatedStorageFile.GetUserStoreForApplication();
    		if (isolatedFileStore.DirectoryExists(dir))
    		{
    			try
    			{
    				using (var stream = new IsolatedStorageFileStream(System.IO.Path.Combine(dir, file), FileMode.Open, isolatedFileStore))
    				{
    					return (T)SerializationHelper.DeserializeData<T>(stream);
    				}
    			}
    			catch (Exception ex)
    			{
    				System.Diagnostics.Debug.WriteLine("Could not retrieve file " + dir + "\\" + file + ". With Exception: " + ex.Message);
    			}
    		}
    		return null;
    	}
    
    	private void SaveSettingToFile<T>(string dir, string file, T data)
    	{
    		IsolatedStorageFile isolatedFileStore = IsolatedStorageFile.GetUserStoreForApplication();
    		if (!isolatedFileStore.DirectoryExists(dir))
    			isolatedFileStore.CreateDirectory(dir);
    		try
    		{
    			string fn = System.IO.Path.Combine(dir, file);
    			if (isolatedFileStore.FileExists(fn)) isolatedFileStore.DeleteFile(fn); //mostly harmless, used because isolatedFileStore is stupid :D
    
    			using (var stream = new IsolatedStorageFileStream(fn, FileMode.CreateNew, FileAccess.ReadWrite, isolatedFileStore))
    			{
    				SerializationHelper.SerializeData<T>(data, stream);
    			}
    		}
    		catch (Exception ex)
    		{
    			System.Diagnostics.Debug.WriteLine("Could not save file " + dir + "\\" + file + ". With Exception: " + ex.Message);
    		}
    	}
    }
