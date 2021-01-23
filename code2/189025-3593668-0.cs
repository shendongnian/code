    public void GetContacts()
    {
        webService.getContactsCompleted += GetContactsCompleted;
        webService.getContactsAsync();
    }
    // NOTE: Should be a private method.
    private void GetContactsCompleted(object sender, getContactsAsyncCompletedEventArgs e)
    { /* ... */ }
