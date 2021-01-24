    List list = web.Lists.GetByTitle("Events");
    ListItemCollection listItems = list.GetItems(cmlqry);
    context.Load(listItems);               
    context.ExecuteQuery();
    if (listItems != null)
    {
        foreach (var listItem in listItems)
        {
            Console.WriteLine("Id: {0}, Title: {1}", listItem["ID"].ToString(), listItem["Title"].ToString());
            context.Load(listItem.AttachmentFiles);
            context.ExecuteQuery();
            foreach (var file in listItem.AttachmentFiles)
            {
                Console.WriteLine("File: {0}", file.FileName);
                var fileRef = file.ServerRelativeUrl;
                var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(context, fileRef);
                var fileName = Path.Combine(@"C:\temp\Events\", String.Format("{0}_{1}", listItem.Id, file.FileName));
                using (var fileStream = System.IO.File.Create(fileName))
                {
                    fileInfo.Stream.CopyTo(fileStream);                               
                }
            }
        }
    }
