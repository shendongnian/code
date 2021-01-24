    public static async void PrintFile(String string1, String, string2 String, string3 String string4 )
    {
        ApplicationData.Current.LocalSettings.Values["param1"] = string1;
        ApplicationData.Current.LocalSettings.Values["param2"] = string2;
        ApplicationData.Current.LocalSettings.Values["param3"] = string3;
        ApplicationData.Current.LocalSettings.Values["param4"] = string4;                
        if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
        {
            try
            {
                await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.ToString());
            }
        }
    }
