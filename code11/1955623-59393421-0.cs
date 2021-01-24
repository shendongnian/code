    public class MyFiles
    {
      public int MyFilesId { get; set; }
      public string Name { get; set; }
      public string Path { get; set; }
    
      protected OnDelete() { // here is logic for removing the file from OS }
    }
    
    public class MyDbContext : DbContext
    {
      public override int SaveChanges()
      {
        // iterate through deletions
        foreach (var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted))
        {
          // if item being deleted is MyFiles, call OnDelete
          if (item.Entity is MyFiles myFile)
            myFile.OnDelete();
        }
        return base.SaveChanges();
      }
    }
