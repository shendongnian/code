    public void Page_Init(object sender, EventArgs e)
    {
       CheckBox chk1 = new CheckBox();
       chk1.ID = "Chk1";
       
       CheckBox chk2 = new CheckBox();
       ck2.ID = "Chk2";
    
       if(!IsPostBack)
       {
          ck1.Checked = true;
          ck2.Checked = true;
       }
    
       p1.Controls.Add(chk1);
       p2.Controls.Add(chk2);
    }
