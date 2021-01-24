    private void UserConfigManagerEvent_CurrentProfileChanging_Handler(object sender,ProfileEventArgs e)
            {
                string profileName = acApp.GetSystemVariable("CPROFILE").ToString();
                curProfile = e.ProfileName;
                if (profileName != curProfile && !IsMessageDisplayed)
                {
                    IsMessageDisplayed = true;
                    MessageBox.Show("The selected profile is not associated with Project");
                }
    
                if (string.IsNullOrEmpty(prevProfile))
                {
                    prevProfile = profileName;
                }
            }
