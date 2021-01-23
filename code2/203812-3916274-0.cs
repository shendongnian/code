            List<String> subscribedEmails = new List<String>();
            ProfileInfoCollection profiles = ProfileManager.GetAllProfiles(ProfileAuthenticationOption.All);
            foreach (ProfileInfo profileInfo in profiles)
            {
                ProfileBase profile = ProfileBase.Create(profileInfo.UserName);
                if ((bool)profile.GetPropertyValue("IsSubscribed"))
                {
                    subscribedEmails.Add((string)profile.GetPropertyValue("Email"));
                }
            }
