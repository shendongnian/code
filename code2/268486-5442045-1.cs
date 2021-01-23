    class FlickrOperation
    {
        //the result:
        //ultimately, hide this and expose a read only collection or something
        public List<string> FlickrPhotoURLs = new List<string>();
        //the event:
        //occurs when all returns photo URLs have been loaded
        public event EventHandler FlickrPhotoURLsLoaded;
        public void BeginGetFlickrPhotoURLs()
        {
            //perform the flickr call...
            var getPhotoCollectionCallback = GetFlickrPhotoURLsCallback;
            flickr.InterestingnessGetListAsync(getPhotoCollectionCallback);
        }
        
        private void GetFlickrPhotoURLsCallback(FlickrResult<PhotoCollection> result)
        {
            //perform the url collection from flickr result...
            FlickrPhotoURLs.Clear();
            var photoCollection = (PhotoCollection)result.Result;
            foreach (Photo photo in photoCollection)
            {
                flickrPhotoUrls.Add(photo.MediumUrl);
            }
            //check to see if event has any subscribers...
            if (FlickrPhotoURLsLoaded != null)
            {
                //invoke any handlers delegated...
                FlickrPhotoURLsLoaded(this, new EventArgs());
            }
        }
    }
