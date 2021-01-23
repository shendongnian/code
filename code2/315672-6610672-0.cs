        RadioButtonList dControl_b = new RadioButtonList();
        dControl_b.ID = "rbl_MinCriteria";
        dControl_b.RepeatDirection = System.Web.UI.WebControls.RepeatDirection.Horizontal;
        dControl_b.CssClass = "Font";
        dControl_b.Font.Name = "Arial";
        dControl_b.Font.Size = 8;
        dControl_b.ToolTip = "";
        dControl_b.SelectedIndex = -1;
        dControl_b.SelectedIndexChanged += new          EventHandler(rbl_MinCriteria_SelectedIndexChanged);
        dControl_b.AutoPostBack = true;
        dControl_b.Items.Add(new ListItem("All provided"));
        dControl_b.Items.Add(new ListItem("Some provided"));
        Panel1.Controls.Add(dControl_b);
    }
    protected void rbl_MinCriteria_SelectedIndexChanged(object sender,EventArgs e)
    {
        RadioButtonList rbl_MinCriteria = (RadioButtonList)Panel1.FindControl("rbl_MinCriteria");
       if(rbl_MinCriteria.SelectedItem.ToString() == "All provided")
       {
      
       }
       if (rbl_MinCriteria.SelectedItem.ToString() == "Some provided")
       {
       
       }
    }
