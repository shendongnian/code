    for (int i = 0; i < lvProject.Items.Count; i++)
    {
        if (((Label)lvProject.Items[i].FindControl("Project_IDLabel")).Text == project.ToString())
        {
            lvProject.SelectedIndex = i;
            break;
        }
     }
