    for (int i = 0; i < chkbx.Items.Count; i++)
    {
        if (myArray.Contains(chkbx.Items[i].Text))
        {
            chkbx.Items[i].Selected = true;
        }
    }
