    class MyPage : Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            Panel p = this.Master.FindControl("panel1") as Panel;  
            p.Visible = false;
        }
    }
