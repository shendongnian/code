    for (int i = 0; i < recordCount; i++)
    {
        Label lblItem = (Label)lvProject.Items[i].FindControl("IdLabel");
        if (lblItem.Text.Equals(itemToSearch))
        {
            lvProject.SelectedIndex = i;
            break;
        }
    }
