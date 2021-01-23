    class MyPage : Page
    {
        public void Page_Load(...)
        {
            Panel p = this.Master.FindControl("panel1") as Panel;  
            p.Visible = false;
        }
    }
