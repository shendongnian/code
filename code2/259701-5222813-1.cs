            using (MusicContainer music = new MusicContainer())
            {
                    Artist artist = new Artist { Name = "Test" };
                    music.Artists.AddObject(artist);
                    music.SaveChanges();
            }
