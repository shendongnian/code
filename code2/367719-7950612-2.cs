    protected void Page_Load(object sender, EventArgs e)
    {
        ((Site)Master).UpdatePanel1.Triggers.Add(new PostBackTrigger() {
                   ControlID= "LinkUploadImageMember" }); 
    }
