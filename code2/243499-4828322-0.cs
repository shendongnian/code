    RadioButton rdb1 = (RadioButton)MyUserControl.FindControl("deleteimage");
    RadioButton rdb2 = (RadioButton)MyUserControl.FindControl("setascover");
    
    rd1.GrouprdoSelect2.GroupName = "radiobutton" + i.ToString() ;
    rd1.ID = "radiobutton" + i.ToString() + i.ToString() + Convert.ToString(1);
    rd1.AutoPostBack = true;
    rd1.CheckedChanged += (thesender, ev) => {
           RadioButton rb =  (RadioButton) thesender;
           MyUserControl mcl = rb.NamingContainer as MyUserControl;
           //Perform your task based on the fact of mcl.ID
       }
    
    rd2.GrouprdoSelect2.GroupName = "radiobutton" + i.ToString() ;
    rd2.ID = "radiobutton" + i.ToString() + i.ToString() + Convert.ToString(2);
    rd2.AutoPostBack = true;
    rd2.CheckedChanged += (thesender, ev) => {
           RadioButton rb =  (RadioButton) thesender;
           MyUserControl mcl = rb.NamingContainer as MyUserControl;
           //Perform your task based on the fact of mcl.ID
       }
