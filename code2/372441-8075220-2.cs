    protected void Tweet_Click(object sender, ImageClickEventArgs e)
    {
        string Twet = txtTweet.InnerText;
        ViewState["twe"] = Twet.ToString();
        string Twttxt = ViewState["twe"].ToString();
        OAuthTokens a = new OAuthTokens();
        a.ConsumerSecret = consumerSecret;
        a.ConsumerKey = consumerKey;
        a.AccessToken = ViewState[" AccessKey "].ToString();
        a.AccessTokenSecret = ViewState["  AccessSecrt"].ToString();
        TwitterResponse<TwitterStatus> tweet = TwitterStatus.Update(a, "" + Twttxt + "");
        txtTweet.Value = "";
        DataList1.Visible = true;
        string nm = ViewState[" Twitter_id"].ToString();
        TimeLineLoad(nm);//function used to fill my tweets in datalist
       
    }
