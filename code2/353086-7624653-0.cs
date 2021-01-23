        public string UploadImage(byte[] imageBytes_, string imageName_)
        {
            string url = string.Empty;
            try
            {
                PicasaEntry newPhoto = null;
                MemoryStream ms = new MemoryStream();
                ms.Write(imageBytes_, 0, imageBytes_.Length);
                if (_albumFeed != null)
                {
                    PicasaEntry photoEntry = new PhotoEntry();
                    photoEntry.MediaSource = new Google.GData.Client.MediaFileSource(ms, imageName_, "image/jpeg");
                    newPhoto = this._service.Insert<PicasaEntry>(new Uri(this._albumFeed.Post), photoEntry);
                }
                url = newPhoto.FeedUri;
            }
            catch (Exception ex)
            {
                throw new DneException("Error while uploading photo", ex );
            }
            return url ;
        }
