    public string Read(string KeyName)  {
    RegistryKey rk = baseRegistryKey;
    // Open a subKey as read-only
    RegistryKey sk1 = rk.OpenSubKey(subKey);
    // If the RegistrySubKey doesn't exist -> (null)
    if ( sk1 == null )
    {
        return null;
    }
    else
    {
        try 
        {
            // If the RegistryKey exists I get its value
            // or null is returned.
            return (string)sk1.GetValue(KeyName.ToUpper());
        }
        catch (Exception e)
        {
            // AAAAAAAAAAARGH, an error!
            ShowErrorMessage(e, "Reading registry " + KeyName.ToUpper());
            return null;
        }
      }
    }
    public bool Write(string KeyName, object Value)  {
      try
      {
          // Setting
          RegistryKey rk = baseRegistryKey ;
          // I have to use CreateSubKey 
          // (create or open it if already exits), 
          // 'cause OpenSubKey open a subKey as read-only
          RegistryKey sk1 = rk.CreateSubKey(subKey);
          // Save the value
          sk1.SetValue(KeyName.ToUpper(), Value);
          return true;
      }
      catch (Exception e) {
            // AAAAAAAAAAARGH, an error!
            ShowErrorMessage(e, "Writing registry " + KeyName.ToUpper());
            return false;
        }
      }    
    public bool DeleteKey(string KeyName)  {
      try
      {
          // Setting
          RegistryKey rk = baseRegistryKey ;
          RegistryKey sk1 = rk.CreateSubKey(subKey);
          // If the RegistrySubKey doesn't exists -> (true)
          if ( sk1 == null )
              return true;
          else
              sk1.DeleteValue(KeyName);
          return true;
      }
      catch (Exception e)
      {
          // AAAAAAAAAAARGH, an error!
          ShowErrorMessage(e, "Deleting SubKey " + subKey);
          return false;
      }
    }
