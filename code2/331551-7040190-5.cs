    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBoxList list = (CheckBoxList)sender;
        string[] control = Request.Form.Get("__EVENTTARGET").Split('$');
        int index = control.Length - 1;
        ListItem li = (ListItem)list.Items[Int32.Parse(control[index])];
    }
