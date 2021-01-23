    protected void btnCheck_Click(object sender, EventArgs e)
    {
        DomainCheck domain = new DomainCheck();
        string ip = domain.GetIPFromDomain(txtDomain.Text.Trim());
        litResponse.Text = String.Format(
                                "IP{0} Found:<br/> - <strong>{1}</strong><br/>{2}",
                                ip.Contains(",") ? "'s" : "",
                                ip.Replace(",", "<br/> - "), domain.VerifyIP(ip));
    }
