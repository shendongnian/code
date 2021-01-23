    protected void addMoreDay_btn_Click(object sender, EventArgs e)
    {
        Control OneMoreDay = LoadControl("~/controls/Days/DayAdd.ascx");
        Days_div.Controls.Add(OneMoreDay);
        Session["MyControl"] += 1
    }
    
    
    protected void Page_Init(object sender, EventArgs e)
    {
        for (int i = 1; i <= (int)Session["MyControl"]; i++) {
            Control OneMoreDay = LoadControl("~/controls/Days/DayAdd.ascx");
            Days_div.Controls.Add(OneMoreDay);        
        }
    }
