    private void saveToIsolatedStorage(string keyname, object value)
    {
      IsolatedStorageSettings isolatedStore = IsolatedStorageSettings.ApplicationSettings;
      isolatedStore.Remove(keyname);
      isolatedStore.Add(keyname, value);
      isolatedStore.Save();
    }
    private bool loadObject(string keyname, out object result)
    {
      IsolatedStorageSettings isolatedStore = IsolatedStorageSettings.ApplicationSettings;
      result = null;
      try
      {
        result = isolatedStore[keyname];
      }
      catch
      {
        return false;
      }
      return true;
    }
