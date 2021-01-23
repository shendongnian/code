    void Page_Load(object sender,EventArgs e) {
        System.Text.StringBuilder clientIDs = new System.Text.StringBuilder();
        IEnumerator myEnumerator = Controls.GetEnumerator();
        while(myEnumerator.MoveNext()) {
            Control   myControl = (Control) myEnumerator.Current;
            clientIDs.AppendFormat("\t\"{0}\" : \"{1}\",\n", myControl.ID, myControl.ClientID);
        }
        page.ClientScript.RegisterStartupScript(page.GetType(),
                                                "ClientId",
                                                "window.ClientIDs = {" + clientIDs.ToString().Substring(0, clientIDs.ToString().Length - 2) + "};",
                                                true);
    }
