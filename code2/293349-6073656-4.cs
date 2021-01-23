    int i = 0;
    foreach (var item in CheckBoxList.Items)
    {
        if  (item.Selected)
        {
            lb = FindControl("Label" + i);
            if(lb != null)
                ((Label)lb).Text = selected.ElementAt(i).Value;
            i++;
        }
    }
