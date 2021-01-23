       protected override void Execute(NativeActivityContext context)
        {
            //Some data processing....
    
            //Obtain the activity extension
            MyActivityExtensionFactory extensionFactory = context.GetExtension<MyActivityExtensionFactory >();
            MyActivityExtension extension = extensionFactory.Create();
    
            string bookmarkName = "MyActivity_" + Guid.NewGuid().ToString();
            var bookmark = context.CreateBookmark(bookmarkName, BookmarkResumed);
    
            extension.ProcessData(bookmarkName);
        }
