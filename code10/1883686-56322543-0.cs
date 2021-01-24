    var toastContent = new ToastContent()
    {
        Visual = new ToastVisual()
        {
            BindingGeneric = new ToastBindingGeneric()
            {
                Children = 
                {
                    new AdaptiveText()
                    {
                        Text = "Matt sent you a friend request"
                    },
                    new AdaptiveText()
                    {
                        Text = "Hey, wanna dress up as wizards and ride around on our hoverboards together?"
                    }
                },
                AppLogoOverride = new ToastGenericAppLogo()
                {
                    Source = "https://unsplash.it/64?image=1005",
                    HintCrop = ToastGenericAppLogoCrop.Circle
                }
            }
        },
        Actions = new ToastActionsCustom()
        {
            Buttons = 
            {
                new ToastButton("Accept", "action=acceptFriendRequest&userId=49183")
                {
                    ActivationType = ToastActivationType.Background
                },
                new ToastButton("Decline", "action=declineFriendRequest&userId=49183")
                {
                    ActivationType = ToastActivationType.Background
                }
            }
        },
        Launch = "action=viewFriendRequest&userId=49183"
    };
    
    // Create the toast notification
    var toastNotif = new ToastNotification(toastContent.GetXml());
    
    // And send the notification
    ToastNotificationManager.CreateToastNotifier().Show(toastNotif);
      
