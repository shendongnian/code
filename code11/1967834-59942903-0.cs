    private async void Button_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = "using FolderPicker or broadFileSystemAccess to get it."
            List<string> fileTypeFilter = new List<string>();
            fileTypeFilter.Add(".txt");
            QueryOptions queryOptions = new QueryOptions(Windows.Storage.Search.CommonFileQuery.OrderByName, fileTypeFilter);
            StorageFileQueryResult queryResult = folder.CreateFileQueryWithOptions(queryOptions);
            var files = await queryResult.GetFilesAsync();
            int count = files.Count;
            foreach (var file in files) {
                string name = file.Name;
            }
        }
           
