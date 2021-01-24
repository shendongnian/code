    private void SaveDomainCredentials_OnClick(object sender, RoutedEventArgs e)
    {
        if ( CredentialList.ItemsSource is NameList nameList )
        {
            nameList.Add(new SetCredentialsForAD("", "", ""));
        }
    }
