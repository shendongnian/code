    if(items.SelectedItem== null)
    {
         item.BList.Add(AllList.Where(x => x.Id == id).FirstOrDefault());
         item.Blist.RemoveAll(i => i == null); // You donn't have to iterate the list to do this
         foreach (var dep in item.Blist)
         {    
              // Do whatever you want with your items or just remove the forach loop altogether
              // item.Blist.RemoveAll(item => dep == null); // don't have to do this here
         }
         return;
    }
