    private void buddyAddYouRequest(object sender, string buddy,
            string requestMessage, ref bool bAccept)
    {
        bool bAcceptCopy = bAccept;
        this.Invoke(new Action(() => OnBuddyAddYouRequest(sender, buddy,
                                     requestMessage, ref bAcceptCopy)));
        bAccept = bAcceptCopy;
    }
    // ...
    yahoo.OnBuddyAddYouRequest += buddyAddYouRequest;
