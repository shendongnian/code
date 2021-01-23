    HtmlImage imgSrf = new HtmlImage();
    HtmlAnchor hlSubmitSRF = new HtmlAnchor();
    HtmlGenericControl hlSubmitSRFText = new HtmlGenericControl("span");
    if (srf.Count > 0) {
    	actiontext = "View active SRF";
    	hlSubmitSRF.HRef = "SRF_Submit.aspx?SRF_ID=" + srf(0).Srf_id.ToString();
    	imgSrf.Src = "images/Arrow_Right_Red.png";
    } else {
    	actiontext = "Submit SRF";
    	hlSubmitSRF.HRef = "SRF_Submit.aspx?APPID=" + app.Appid.ToString();
    	imgSrf.Src = "images/Arrow_Right_Green.png";
    }
    imgSrf.Alt = actiontext;
    hlSubmitSRF.Controls.Add(imgSrf);
    hlSubmitSRFText.InnerHtml = actiontext;
    hlSubmitSRF.Controls.Add(hlSubmitSRFText);
    ParentControl.Controls.Add(hlSubmitSRF);
