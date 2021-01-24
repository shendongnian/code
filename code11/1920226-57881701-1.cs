     modelBuilder.Entity<FolderObject>()
            .HasKey(bc => new { bc.FolderID, bc.ObjectID });  
        modelBuilder.Entity<FolderObject>()
            .HasOne(bc => bc.Folder)
            .WithMany(b => b.FolderObjects)
            .HasForeignKey(bc => bc.FolderID);  
        modelBuilder.Entity<FolderObject>()
            .HasOne(bc => bc.Object)
            .WithMany(c => c.FolderObjects)
            .HasForeignKey(bc => bc.ObjectID);
