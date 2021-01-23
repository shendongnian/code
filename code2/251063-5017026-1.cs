    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PlaceHolder1.Controls.Add(new Button(){
                Text = "Added"}
            );
    
        }
    }
