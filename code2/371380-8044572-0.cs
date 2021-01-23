    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Form.Attributes["onsubmit"] = string.Format(@"$(""#{0}"").val($(""#{1}"").html());", hidden.ClientID, div.ClientID);
        }
    }
