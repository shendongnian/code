    public static void Save<TSetting>(Func<TSetting> howToGetSetting)
    {
      TSetting setting = howToGetSetting();
      //... rest as above.
    
    }
    
