    if (AuctionID > 0 && LoginErrorCode == 0 && BidStatus > 0)
    {
        this._dealBidPlacedControl.Visible = true;
    }
    else if (AuctionID > 0 && LoginErrorCode == 0 && AuctionID <= 0)
    {
        this._dealBidControl.Visible = true;
    }
    else if (AuctionID > 0 && LoginErrorCode != 0)
    {
        this._loginReg.LoginErrorType = LoginErrorCode;
        this._loginReg.Visible = true;
        this._deals.Visible = true;
    }
    else if(AuctionID <= 0)
    {
        this._loginReg.Visible = true;
        this._deals.Visible = true;
    }
