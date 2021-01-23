        CheckBoxList chkList = new CheckBoxList();
        CheckBox chk = new CheckBox();
        chkList.ID = "ChkUser";
        chkList.AutoPostBack = true;
        chkList.RepeatColumns = 6;
        chkList.DataSource = us.GetUserDS();
        chkList.DataTextField = "User_Name";
        chkList.DataValueField = "User_Id";                        
        chkList.DataBind();
        Panel pUser = new Panel();
        if (pUserGrp != "")   
        {
            pUser.GroupingText = pUserGrp ;
            chk.Text = pUserGrp;            
        }
        else 
        {
            pUser.GroupingText = "Non Assigned Group";
            chk.Text = "Non Assigned group";
        }
        pUser.Controls.Add(chk);
        pUser.Controls.Add(chkList);
        this.Form.Controls.Add(pUser);   
