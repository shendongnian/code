        try
        {
            // If new value is different, set the new value
            if(!settingsStorage.ContainsKey(key))
            {
                settingsStorage.Add(key, value);
                valueChanged = true;
            }
            else if(settingsStorage[key] != value)
            {
                settingsStorage[key] = value;
                valueChanged = true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception occured whilst using IsolatedStorageSettings: " + e.ToString());
        }
