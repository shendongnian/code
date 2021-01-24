    if(items.SelectedItem== null)
    {
         item.BList.Add(AllList.Where(x => x.Id == id).FirstOrDefault());
         item.Blist.RemoveAll(item => item == null);
    
         return;
    }
