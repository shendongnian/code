    private delegate void updateUIDelegate();
    
    public void updateUI()
    {
        if (lblAirTrack.InvokeRequired)
        {
            lblAirTrack.Invoke(new updateUIDelegate(updateUI));
        }
        else
        {
            lblAirTrack.Text = "Tracking: " + itemList.Count + " items";
        }
    }
