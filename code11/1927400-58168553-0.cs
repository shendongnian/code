            string FisrtString = "Temp";
            string SecondString = "Temp";
            string SubBaseKeyString = @"SOFTWARE\ApplicationName";
            RegistryKey vmsBaseKey = Registry.CurrentUser.OpenSubKey(SubBaseKeyString, true);
            if (vmsBaseKey != null)
            {
                var Value = vmsBaseKey.GetValue("Validate");
                if (Value != null)
                {
                    if (Value.ToString() == "1")
                    {
                        //The user check passed here, you can open the window
                    }
                }
                else
                {
                    //Here you must specify the action if the key is missing. Additional string comparison possible
                }
            }
            else
            {
                if (FisrtString == SecondString)
                {
                    //If the first line is equal to the second line, then assign a value
                    //The user check passed here, you can open the window
                    RegistryKey KEY_CREATE = Registry.CurrentUser.CreateSubKey(SubBaseKeyString);
                    KEY_CREATE.SetValue("Validate", "1");
                    KEY_CREATE.Close();
                }
                else
                {
                    //If the first line is not equal to the second line, then we perform the desired action
                }
            }
