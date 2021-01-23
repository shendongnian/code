    protected void Page_Load(object sender, EventArgs e)
    {
            ((Site)Master).MyUpdatePanel.Triggers.Add(new PostBackTrigger() {
                  ControlID = LinkUploadImageMember.UniqueID });
    }
