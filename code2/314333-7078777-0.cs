                string username = form["UserName"].ToString(); // <-- ### USERNAME HERE ###
                string password = form["Password"].ToString(); // <-- ### PASSWORD HERE ###
                PicasaService picasaService = new PicasaService("Tester");
                picasaService.setUserCredentials(username, password);
                // 2. Create a test album
                //
                AlbumEntry entry = new AlbumEntry();
                entry.Title.Text = "test-69";
                entry.Summary.Text = "test-69";
                AlbumAccessor access = new AlbumAccessor(entry);
                PicasaEntry album = picasaService.Insert(new Uri(PicasaQuery.CreatePicasaUri(username)), entry);
                access = new AlbumAccessor(album);
                // 3. Upload a photo
                picasaService.Insert(new Uri(PhotoQuery.CreatePicasaUri(username, access.Id)), System.IO.File.OpenRead("thumb-1.jpg"), "image/jpeg", "thumb-1.jpg");
