    public class YourWebPart
    {
        public string CancelUrl { get; set; }
        protected override void CreateChildControls()
        {
            // Build the part
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(CancelUrl ?? "Example.aspx");
        }
    }
