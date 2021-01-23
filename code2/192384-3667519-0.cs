    private void ContainerList_SelectedIndexChanged(Object sender, EventArgs e) 
    {
       Container container = (Container)ContainerList.SelectedItem;
       for(int i = 0; i < List.Items.Count; i++)
       {
          List.Items[i].Selected = container.Items.Contains(List.Items[i]);
       }
    }
