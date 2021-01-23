        private const string BookmarkFileName = "Bookmarks.json";
        private void LoadBookmarks()
        {
            BookmarkViewModel = new AppBookmarkViewModel();
            try
            {
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (false == store.FileExists(BookmarkFileName))
                    {
                        return;
                    }
                    using (var fs = store.OpenFile(BookmarkFileName, System.IO.FileMode.Open))
                    {
                        using (var sr = new StreamReader(fs))
                        {
                            var text = sr.ReadToEnd();
                            BookmarkViewModel = JsonConvert.DeserializeObject<AppBookmarkViewModel>(text);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                BookmarkViewModel = new AppBookmarkViewModel();
                MessageBox.Show("Sorry - there was a problem reading bookmarks - " + exc.Message);
            }
        }
        public void SaveBookmarks()
        {
            try
            {
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (store.FileExists(BookmarkFileName))
                    {
                        store.DeleteFile(BookmarkFileName);
                    }
                    using (var fs = store.OpenFile(BookmarkFileName, System.IO.FileMode.CreateNew))
                    {
                        using (var sw = new StreamWriter(fs))
                        {
                            var text = JsonConvert.SerializeObject(BookmarkViewModel);
                            sw.Write(text);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                // don't show message box during shutdown
                //MessageBox.Show("Sorry - there was a problem reading bookmarks - " + exc.Message);
            }
        }
