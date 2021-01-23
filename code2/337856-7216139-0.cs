        private void Update()
        {
            try
            {
                ApplicationDeployment.CurrentDeployment.CheckForUpdateCompleted += new CheckForUpdateCompletedEventHandler(CurrentDeployment_CheckForUpdateCompleted);
                ApplicationDeployment.CurrentDeployment.UpdateCompleted += new System.ComponentModel.AsyncCompletedEventHandler(CurrentDeployment_UpdateCompleted);
                ApplicationDeployment.CurrentDeployment.CheckForUpdateAsync();
            }
            catch (Exception)
            {
            }
        }
        void CurrentDeployment_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            try
            {
                if (e.UpdateAvailable)
                {
                    ApplicationDeployment.CurrentDeployment.UpdateAsync();
                }
            }
            catch (InvalidOperationException)
            {
            }
        }
        void CurrentDeployment_UpdateCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //TODO: update completion code here
        }
