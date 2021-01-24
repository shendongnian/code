     private int GetIndex(ObservableCollection<ExplorerItem> DataSource)
     {
         int index = 0;
         foreach (var item in DataSource)
         {
             if (item.IsSelected == true)
             {
                 index = DataSource.IndexOf(item);                 
             }
         }
         return index;
     }
