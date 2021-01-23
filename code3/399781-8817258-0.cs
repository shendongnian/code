    bool hasAuction = AuctionID > 0;
    bool hasLoginError = LoginErrorCode != null;
    bool hasBidStatus = BidStatus > 0;
    this._dealBidPlacedControl.Visible = hasAction && !hasLoginError && hasBidStatus;
    this._dealBidControl.Visible = hasAction && !hasLoginError && !hasBidStatus;
    this._loginReg.Visible = this._deals.Visible = !hasAction || hasLoginError;
        
    if (hasAuction && hasLoginError)
    {
      this._loginReg.LoginErrorType = LoginErrorCode;
    }
				
    if (IsGetMoreTokens)
    {
      this._getMoreTokens.Visible = true;
      this._loginReg.Visible = false;
      this._deals.Visible = false;     
    }
    // set the hidden field which can be used to set visibility if included in a tab control or anything
    // by the parent site
    if (this.AuctionID > 0 || BidStatus > 0 || IsHome > 0 || LoginErrorCode > 0 || IsGetMoreTokens)
            this._visibilityStatus.Value = "1"; 
