    foreach (Photo p in photos)
            {
                Photo photo = p;
                Task.Factory.StartNew(() =>
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile(photo.src_big, "C:\\pic" + photo.ID + ".jpg");
                    });
            }
