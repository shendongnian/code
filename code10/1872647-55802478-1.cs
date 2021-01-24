    class MLWrapper
    {
        private readonly MLApp.MLApp _mlapp;
        public MLWrapper(bool visible = false)
        {
            _mlapp = new MLApp.MLApp();
            
            if (visible)
                ShowConsole();
            else
                HideConsole();
        }
        ~MLWrapper()
        {
            Run("close all");
            _mlapp.Quit();
        }
        public void ShowConsole()
        {
            _mlapp.Visible = 1;
        }
        public void HideConsole()
        {
            _mlapp.Visible = 0;
        }
        /// <summary>
        /// Run a MATLAB command.
        /// </summary>
        /// <returns>Text output displayed in MATLAB console.</returns>
        public string Run(string cmd)
        {
            return _mlapp.Execute(cmd);
        }
        /// <summary>
        /// Run a MATLAB script.
        /// </summary>
        /// <returns>Text output displayed in MATLAB console.</returns>
        public string RunScript(string scriptName)
        {
            return Run($"run '{scriptName}'");
        }
        /// <summary>
        /// Change MATLAB's current working folder to the specified directory.
        /// </summary>
        public void CD(string directory)
        {
            Run($"cd '{directory}'");
        }
        public object GetVariable(string varName)
        {
            _mlapp.GetWorkspaceData(varName, "base", out var data);
            return data;
        }
        public void SetVariable(string varName, object value)
        {
            _mlapp.PutWorkspaceData(varName, "base", value);
        }
    }
