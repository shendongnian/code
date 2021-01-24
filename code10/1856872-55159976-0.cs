    private void CheckIsMetered()
    {
        var profile = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
        IsInternetAvailable = profile != null && profile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
        if (IsInternetAvailable)
            IsMetered = profile.GetConnectionCost().NetworkCostType != Windows.Networking.Connectivity.NetworkCostType.Unrestricted;
    }
