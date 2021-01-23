     using (MusicContainer music = new MusicContainer())
                {
                    using (TransactionScope transaction = new TransactionScope(TransactionScopeOptions.RequiresNew))
                        {
                
                                Artist artist = new Artist { Name = "Test" };
                                music.Artists.AddObject(artist);
        
                            // The transaction ended without Complete(); shouldn't the changes be abandoned?
                            music.SaveChanges();
                        }
                }
