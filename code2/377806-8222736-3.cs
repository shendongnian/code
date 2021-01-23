        /// <summary>
        /// Configure profile from file to Asf file writer
        /// </summary>
        /// <param name="asfWriter"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool ConfigProfileFromFile(IBaseFilter asfWriter, string filename)
        {
            int hr;
            //string profilePath = "test.prx";
            // Set the profile to be used for conversion
            if ((filename != null) && (File.Exists(filename)))
            {
                // Load the profile XML contents
                string profileData;
                using (StreamReader reader = new StreamReader(File.OpenRead(filename)))
                {
                    profileData = reader.ReadToEnd();
                }
                // Create an appropriate IWMProfile from the data
                // Open the profile manager
                IWMProfileManager profileManager;
                IWMProfile wmProfile = null;
                hr = WMLib.WMCreateProfileManager(out profileManager);
                if (hr >= 0)
                {
                    // error message: The profile is invalid (0xC00D0BC6)
                    // E.g. no <prx> tags
                    hr = profileManager.LoadProfileByData(profileData, out wmProfile);
                }
                if (profileManager != null)
                {
                    Marshal.ReleaseComObject(profileManager);
                    profileManager = null;
                }
                // Config only if there is a profile retrieved
                if (hr >= 0)
                {
                    // Set the profile on the writer
                    IConfigAsfWriter configWriter = (IConfigAsfWriter)asfWriter;
                    hr = configWriter.ConfigureFilterUsingProfile(wmProfile);
                    if (hr >= 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
