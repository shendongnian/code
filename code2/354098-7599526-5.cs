     /// <summary>
     /// Method automatically called and used to register the module's views, types, 
     /// as well as initialize the module itself.
     /// </summary>
     public void Initialize()
     {
         // Views and types must be registered first.
         RegisterViewsAndTypes();
            
         // Now initialize the module.
         InitializeModule();
         // Flag the module as loaded.
         FlagModuleAsLoaded();
     }
     public abstract void FlagModuleAsLoaded();
