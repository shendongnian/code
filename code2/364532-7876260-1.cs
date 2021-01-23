        public IList<Dictionary> GetListPerCategory_Icon(string category, string xmlFileName)
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (storage.FileExists(xmlFileName))
                {
                    using (Stream stream = storage.OpenFile(xmlFileName, FileMode.Open, FileAccess.Read))
                    {
                        try
                        {
                            loadedData = XDocument.Load(stream);
                            var data = from query in loadedData.Descendants("category")
                                       where query.Element("name").Value == category
                                       select new Glossy_Test.Dictionary
                                       {
                                            Image=GetImage((string)query.Element("iconpress")),//This is a function which will return Bitmap image
                                       };
                            categoryList = data.ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), (((PhoneApplicationFrame)Application.Current.RootVisual).Content).ToString(), MessageBoxButton.OK);
                            return categoryList = null;
                        }
                    }
                }
            }
            return categoryList;
        }
