    private void SetVisibility( VisibilityParameters parameters )
    {
        this._dealBidPlacedControl.Visible = DealBidPlaceVisible( parameters );
        etc.
    }
    private bool DealBidPlaceVisible( VisibilityParameters parameters )
    {
         return parameters.AuctionID > 0 && parameters.LoginErrorCode == 0 && parameters.BidStatus > 0
    }
