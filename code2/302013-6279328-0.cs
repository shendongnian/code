    Messenger.Default.Register<AboutToCloseMessage>(this, SomeMethod);
    void SomeMethod(SomeType msg)
    {
        if (msg.TheContainer == this.MyContainer) // only care if my container.
        {
            // decide whether or not we should cancel the Close
            if (!(this.MyContainer.CanIClose))
            {
                 msg.Execute(true); // indicate Cancel status via msg callback.
            }
        }
    }
