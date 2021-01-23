    for (int i = 0; i < chkbx.Items.Count; i++)
    {
        if (myArray.Contains(chkbx.Text))
        {
            chkbx.Items[i].Selected = true;
        }
    }
