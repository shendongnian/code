            static void Main(string[] args)
            {
                string accountName = "xxx";
                string key = "xxxx";
                var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);
                var share = storageAccount.CreateCloudFileClient().GetShareReference("testfolder");
                IEnumerable<IListFileItem> fileList = share.GetRootDirectoryReference().ListFilesAndDirectories();
                foreach (IListFileItem listItem in fileList)
                {
                    if (listItem.GetType() == typeof(CloudFile))
                    {
                        Console.WriteLine(listItem.Uri.Segments.Last());
                    }
                    else if(listItem.GetType() == typeof(CloudFileDirectory))
                    {
                        list_subdir(listItem);
                    }
                }
    
                Console.WriteLine("done now");
                Console.ReadLine();
            }
    
            public static void list_subdir(IListFileItem list)
            {
                //Console.WriteLine("subdir");
                CloudFileDirectory fileDirectory = (CloudFileDirectory)list;
                IEnumerable<IListFileItem> fileList = fileDirectory.ListFilesAndDirectories();
    
                foreach (IListFileItem listItem in fileList)
                {
                    if (listItem.GetType() == typeof(CloudFileDirectory))
                    {
                        list_subdir(listItem);
                    }
                    else
                    {
                        Console.WriteLine(listItem.Uri.Segments.Last());
                    }
                }
    
            }
