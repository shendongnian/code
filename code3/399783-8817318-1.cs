    private void SetVisibility(int AuctionID, int BidStatus, int LoginErrorCode, int     IsHome, bool IsGetMoreTokens)
    {
        this._dealBidPlacedControl.Visible = AuctionID > 0 && LoginErrorCode == 0 && BidStatus > 0;
        this._dealBidControl.Visible = AuctionID > 0 && LoginErrorCode == 0 && BidStatus <= 0;
        this._loginReg.LoginErrorType = LoginErrorCode;
        this._loginReg.Visible = !IsGetMoreTokens && LoginErrorCode != 0;
        this._deals.Visible = !IsGetMoreTokens && LoginErrorCode != 0;
        this._getMoreTokens.Visible = IsGetMoreTokens;
    
        // set the hidden field which can be used to set visibility if included in a tab control or anything
        // by the parent site
        if (this.AuctionID > 0 || BidStatus > 0 || IsHome > 0 || LoginErrorCode > 0 || IsGetMoreTokens)
            this._visibilityStatus.Value = "1";   
    }
