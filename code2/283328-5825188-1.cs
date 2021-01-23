    if(!this.IsPostBack) 
    {
        DropDownList p_status = edit_program.FindControl("p_status") as DropDownList;
        p_status.Items.Add(new ListItem("Green", "Green"));
        p_status.Items.Add(new ListItem("Yellow", "Yellow"));
        p_status.Items.Add(new ListItem("Red", "Red"));
        //myProgram.Status = "Red";
        p_status.SelectedValue = myProgram.Status;
     }
