    void toClient_GetVenuesCompleted(object sender, GetVenuesCompletedEventArgs e)
    {
        if(e.Error == null)
        {
            VenueViewModel vvm = new VenueViewModel();
            vvm.Venues = e.Result;
            MessageBox.Show(vvm.Venues.Count.ToString());
        }
    }
