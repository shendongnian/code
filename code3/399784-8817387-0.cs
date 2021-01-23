    private void SetVisibility(int AuctionID, int BidStatus, int LoginErrorCode, int     IsHome, bool IsGetMoreTokens)
    {
        this._dealBidPlacedControl.Visible = AuctionID > 0 && LoginErrorCode == 0 && BidStatus > 0;
        this._dealBidControl.Visible       = AuctionID > 0 && LoginErrorCode == 0 && BidStatus <= 0;
        this._loginReg.Visible             = AuctionID > 0 && LoginErrorCode != 0;
        this._deals.Visible                = AuctionID > 0 && LoginErrorCode != 0;
        etc.
    }
