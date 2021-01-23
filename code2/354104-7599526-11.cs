     /// <summary>
     /// Method used to alert the Shell Handler that a new module has been loaded.
     /// Used by the Shell Handler to determine when all modules have been loaded
     /// and the Login shell can be displayed.
     /// </summary>
     public override void FlagModuleAsLoaded()
     {
         ShellHandler.FlagModuleAsLoaded();
     }
