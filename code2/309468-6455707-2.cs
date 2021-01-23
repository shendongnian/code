    public void BindClients()
    {
        //To Bind the Client Names for Searching Option
        var ddlclientnames = (from ddl in mortgageentity.Clients select ddl).ToList();
        if (ddlclientnames.Any)
        {
            ddlsearchclient.DataSource = ddlclientnames;
            ddlsearchclient.DataValueField = "Client_ID";
            ddlsearchclient.DataTextField = "FullName";
            ddlsearchclient.DataBind();
        }
    }
