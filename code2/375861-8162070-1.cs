    private static WebDocument Document;
    private static readonly object Locker = new object();
    
    [WebMethod(true)]
    public static string Index(string uri)
    {
      WebDocument document = WebDocument.Get(uri);
    
      if (document == null)
        document = WebDocument.Create(uri);
    
      Document = document;
    
      // start a new background thread
      var System.Threading.Tasks.task = Task.Factory.StartNew(() => IndexThisPage);
    
      //document.Index();
    
      return "OK";
    }
    
    public static void IndexThisPage()
    {
      lock (Locker)
      {
        Document.Index();
      }
    }
