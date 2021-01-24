    public async void PushNotification()
        {
            var receiptInstallID = new Dictionary<string, string>
                    {
                        {"17593989838", "Android" }
                    };
            var customData = new Dictionary<string, string>
                    {
                        {"taskId", "1234" }
                    };
            AppCenterPush appCenterPush = new AppCenterPush(receiptInstallID);
            await appCenterPush.Notify("Hello", "How are you?", customData);
        }
