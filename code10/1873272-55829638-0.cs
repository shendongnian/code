    void InitiateDataBase()
    {
        //Some codes before...
        if (ShouldRecreateDataBase())
        {
    #if !DEBUG
            DeleateDataBase();
            CreateDataBase();
    #endif
        }
        //Some codes after...
      }
