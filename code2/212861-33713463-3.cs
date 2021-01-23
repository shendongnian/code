    public static [ObjectType] LoadWithRecovery(string fileName)
    {
        try
        {
            return Load(fileName);
        }
        catch(Excetion)
        {
            File.Delete(fileName); //delete corrupted settings file
            return GetFactorySettings();
        }
    }
