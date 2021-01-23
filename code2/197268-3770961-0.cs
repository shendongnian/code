    protected void btn_returnUserList(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        CheckBoxList cbl = sender as CheckBoxList;
        if (sender == null) {
            throw new Exception("Sender is not a CheckBoxList");
        }
        
        for (int i = 0; i < cbl.Items.Count; i++)
        {
            if (cbl.Items[i].Selected)
            {
                //  Also, set a breakpoint here... are you hitting this line?
                selectedUsers += cbl.Items[i].Text;
            }
        }
