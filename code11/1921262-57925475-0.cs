    protected override void OnActivated(IActivatedEventArgs e)
    {
        // Get the root frame
        Frame rootFrame = Window.Current.Content as Frame;
     
        // TODO: Initialize root frame just like in OnLaunched
     
        // Handle toast activation
        if (e is ToastNotificationActivatedEventArgs)
        {
            var toastActivationArgs = e as ToastNotificationActivatedEventArgs;
                     
            // Parse the query string (using QueryString.NET)
            QueryString args = QueryString.Parse(toastActivationArgs.Argument);
     
            // See what action is being requested 
            switch (args["action"])
            {
                // Open the image
                case "viewImage":
     
                    // The URL retrieved from the toast args
                    string imageUrl = args["imageUrl"];
     
                    // If we're already viewing that image, do nothing
                    if (rootFrame.Content is ImagePage && (rootFrame.Content as ImagePage).ImageUrl.Equals(imageUrl))
                        break;
     
                    // Otherwise navigate to view it
                    rootFrame.Navigate(typeof(ImagePage), imageUrl);
                    break;
                                 
     
                // Open the conversation
                case "viewConversation":
     
                    // The conversation ID retrieved from the toast args
                    int conversationId = int.Parse(args["conversationId"]);
     
                    // If we're already viewing that conversation, do nothing
                    if (rootFrame.Content is ConversationPage && (rootFrame.Content as ConversationPage).ConversationId == conversationId)
                        break;
     
                    // Otherwise navigate to view it
                    rootFrame.Navigate(typeof(ConversationPage), conversationId);
                    break;
            }
     
            // If we're loading the app for the first time, place the main page on
            // the back stack so that user can go back after they've been
            // navigated to the specific page
            if (rootFrame.BackStack.Count == 0)
                rootFrame.BackStack.Add(new PageStackEntry(typeof(MainPage), null, null));
        }
     
        // TODO: Handle other types of activation
     
        // Ensure the current window is active
        Window.Current.Activate();
    }
