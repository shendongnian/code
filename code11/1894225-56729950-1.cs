    public async Task CheckContactsData(string contact,CancellationTokenSource cts)
    {
        try
        {
            var getcontactschanges = Constants.conn.QueryAsync<ContactsTable>("SELECT * FROM tblContacts WHERE Supervisor = ? AND LastUpdated > LastSync AND Deleted != '1'", contact);
            var contactchangesresultCount = getcontactschanges.Result.Count;
    
            Preferences.Set("contactschanges", contactchangesresultCount.ToString(), "private_prefs");
        }
        catch (Exception ex)
        {
            cts.Cancle();
            Crashes.TrackError(ex);
            var retry = await App.Current.MainPage.DisplayAlert("Checking Retailer Error", "Checking retailer failed.\n\nDo you want to retry? \n\n Error:\n\n" + ex.Message, "Yes", "No");
    
            if (retry)
            {
                await CheckContactsData(contact);
            }
            else {
                //Pending task should be stop
            }
        }
    }
