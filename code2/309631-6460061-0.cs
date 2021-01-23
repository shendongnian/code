    <asp:HyperLink ID="hlSubmitSrf" runat="server" Target="_blank"></asp:HyperLink>     
        if (srf.Count > 0)
        {
            actionText = "View active SRF";
            hlSubmitSRF.Text = actionText;
            hlSubmitSRF.NavigateUrl = "SRF_Submit.aspx?SRF_ID=" + srf[0].Srf_id.ToString();                
            hlSubmitSRF.ImageUrl = "images/Arrow_Right_Red.png";
        }
        else
        {
            actionText = "Submit SRF";
            hlSubmitSRF.Text = actionText;
            hlSubmitSRF.NavigateUrl = "SRF_Submit.aspx?APPID=" + app.Appid.ToString();                
            hlSubmitSRF.ImageUrl = "images/Arrow_Right_Green.png";
        }
       
