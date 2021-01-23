    public ContentData getContent()
    {
         return new ContentData
         {
            Title = "Hello World",
            Artist = "Some Other String"
         };
    }
    ContentData data = someobject.getContent();
    text1.Text = data.Title; 
    // etc
