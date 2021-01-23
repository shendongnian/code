     using (MusicContainer music = new MusicContainer())
       {
         using (TransactionScope transaction = new TransactionScope(TransactionScopeOptions.RequiresNew))
              {
                  Artist artist = new Artist { Name = "Test" };
                  music.Artists.AddObject(artist);
                  music.SaveChanges();
                  scope.Complete(); 
              }
        }
