         "goog:chromeOptions": {
            
            "excludeSwitches": [ "enable-automation" ],
            "useAutomationExtension": false
         }
            /// <summary>
        /// Adds a single argument to be excluded from the list of arguments passed by default
        /// to the browser executable command line by chromedriver.exe.
        /// </summary>
        /// <param name="argument">The argument to exclude.</param>
        public void AddExcludedArgument(string argument)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentException("argument must not be null or empty", "argument");
            }
            this.AddExcludedArguments(argument);
        }
