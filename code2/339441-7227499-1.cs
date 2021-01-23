    public static void BeginGetUserInfo(string fobID)
    {
        MyClient client = new MyClient(availableEndpoints[activeEndpointIndex].Name);
        client.GetUserInfoCompleted += new EventHandler<GetUserInfoCompletedEventArgs>(client_GetUserInfoCompleted);
        client.GetUserInfoAsync(fobID, fobID);
    }
    static void client_GetUserInfoCompleted(object sender, GetUserInfoCompletedEventArgs e)
    {
        string fobID = e.UserState as string;
        // handle the event here...
    }
