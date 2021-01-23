    private void Move(ListControl source, ListControl destination)
    {
           List<ListItem> remove = new List<ListItem>();
           foreach(var item in source.Items)
           {
                if(item.Selected == false) continue;
                destination.Items.Add(item);
                remove.Add(item);
           }
           foreach(var item in remove)
           {
                source.Items.Remove(item);
           }
    }
