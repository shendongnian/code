    public static bool TestConnectedToCellular()
    {
        try
        {
            if (NetworkInformation.GetInternetConnectionProfile() is ConnectionProfile connectionProfile)
            {
                return connectionProfile.IsWwanConnectionProfile;
            }
        }
        catch
        {
            return false;
        }
        return false;
    }
