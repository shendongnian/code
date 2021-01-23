    public class SegmentedDownloader
    {
        #region Class Variables
        /// <summary>
        /// Date the file was last updated
        /// Used to compare the header file for changes since
        /// </summary>
        protected DateTime LastModifiedSince = default(DateTime);
        /// <summary>
        /// Length of the file when it was last downlaoded
        /// (this will be used to provide a content offset on next download)
        /// </summary>
        protected Int64 ContentLength = default(Int64);
        /// <summary>
        /// The file we're polling
        /// </summary>
        protected Uri FileLocation;
        #endregion
        #region Construct
        /// <summary>
        /// Create a new downloader pointing to the specific file location
        /// </summary>
        /// <param name="URL">URL of the file</param>
        public SegmentedDownloader(String URL)
            : this(new Uri(URL))
        {
        }
        public SegmentedDownloader(Uri URL)
        {
            this.FileLocation = URL;
        }
        #endregion
        /// <summary>
        /// Grab the latests details from the page
        /// </summary>
        /// <returns>Stream with the changes</returns>
        public Stream GetLatest()
        {
            Stream result = null;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(this.FileLocation);
                if (this.ContentLength > 0)
                    webRequest.AddRange(this.ContentLength);
                webRequest.IfModifiedSince = this.LastModifiedSince;
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                Int64 contentLength = webResponse.ContentLength;
                DateTime lastModifiedSince = Convert.ToDateTime(webResponse.Headers["Last-Modified"]);
                if (contentLength > 0 || lastModifiedSince.CompareTo(this.LastModifiedSince) > 0)
                {
                    result = webResponse.GetResponseStream();
                    this.ContentLength += contentLength;
                    this.LastModifiedSince = lastModifiedSince;
                }
            }
            //catch (System.Net.WebException wex)
            //{ // 302 = unchanged
            //    Console.WriteLine("Unchanged");
            //}
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
    }
