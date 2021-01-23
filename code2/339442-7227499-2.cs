    public static void BeginGetUserInfo(string fobID)
    {
        MyClient client = new MyClient(availableEndpoints[activeEndpointIndex].Name);
        client.GetUserInfoCompleted += (sender, args) => client_GetUserInfoCompleted(sender, args, fobID);
        client.GetUserInfoAsync(fobID);
    }
    static void client_GetUserInfoCompleted(object sender, GetUserInfoCompletedEventArgs e, string fobID)
    {
        // access the additional parameter fobID here
    }
