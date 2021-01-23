    internal void UpdateMedia(int mediaID, int[] catagoryIDs)
    {
        using (Data.EFEntities context = new Data.EFEntities())
        {
            Data.Media media = context.Media.Single(m => m.MediaID == mediaID);
            foreach(var category in context.Category.Where(cat => catagoryIDs.Contains(cat.CategoryID))
            {
                media.Categories.Add(category);                
            }
    
            context.SaveChanges();
        }
    }
