     const string delim = ",";
            static string adlsInputPath = ConfigurationManager.AppSettings.Get("AdlsInputPath");
    public static void ProcessUserProfile(this SampleProfile, AdlsClient adlsClient, string fileNameExtension = "")
            {
                using (MemoryStream memStreamProfile = new MemoryStream())
                {
                    using (TextWriter textWriter = new StreamWriter(memStreamProfile))
                    {
                        string profile;
                        string header = Helper.GetHeader(delim, Entities.FBEnitities.Profile);
                        string fileName = adlsInputPath + fileNameExtension + "/profile.csv";
                        adlsClient.DataLakeFileHandler(textWriter, header, fileName);
                        profile = socialProfile.UserID                                                
                                        + delim + socialProfile.Profile.First_Name
                                        + delim + socialProfile.Profile.Last_Name
                                        + delim + socialProfile.Profile.Name
                                        + delim + socialProfile.Profile.Age_Range_Min
                                        + delim + socialProfile.Profile.Age_Range_Max
                                        + delim + socialProfile.Profile.Birthday
                                       ;
    
                        textWriter.WriteLine(profile);
                        textWriter.Flush();
                        memStreamProfile.Flush();
                        adlsClient.DataLakeUpdateHandler(fileName, memStreamProfile);
                    }
                }
            }
