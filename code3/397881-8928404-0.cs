            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var stream = new IsolatedStorageFileStream("theme.xaml", FileMode.Open, storage))
                {
                    var xaml = XElement.Load(stream);
                }
            }
