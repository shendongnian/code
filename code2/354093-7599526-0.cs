        /// <summary>
        /// Method used to increment the number of modules loaded.
        /// Once the number of modules loaded equals the number of modules registered in the catalog,
        /// the shell displays the Login shell.
        /// This prevents the scenario where the Shell is displayed at start-up with empty regions,
        /// and then the regions are populated as the modules are loaded.
        /// </summary>
        public void FlagModuleAsLoaded()
        {
            NumberOfLoadedModules++;
            if (NumberOfLoadedModules != ModuleCatalog.Modules.Count()) 
                return;
            // Display the Login shell.
            DisplayShell(typeof(LoginShell), true);
        }
