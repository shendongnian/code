    private bool CheckNet()
    {
        bool stats;
        if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
        {
            stats = true;
        }
        else
        {
            stats = false;
        }
        return stats;
    }
