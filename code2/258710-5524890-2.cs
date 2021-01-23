     public BookUploadViewController() 
       : base("BookUploadViewController", null)
     {
       RequestHandler = new DefaultRequestHandler();
       var defaultActionHandlerFactory = new DefaultActionHandlerFactory();
       RegisterActionHandlers(defaultActionHandlerFactory);
       RequestHandler.AddActionHandlerFactory(defaultActionHandlerFactory);
       
       WebServer = new EmbeddedWebServer(RequestHandler);
     }
     
     void RegisterActionHandlers(DefaultActionHandlerFactory factory)
     {
       factory.RegisterHandler(
         request => request.RawUrl == "/",
         request => new IndexActionHandler(request)
         );
       factory.RegisterHandler(
         request => 
           string.Compare(request.RawUrl, "/Upload", true) == 0 && 
           string.Compare(request.HttpMethod, "POST", true) == 0,
         request => new UploadActionHandler(request)
         );
     }
     
     public override void ViewDidAppear(bool animated)
     {
       base.ViewDidAppear(animated);
       StatusLabel.Text = string.Format("Server listening on\r\nhttp://{0}:8080", GetIPAddress ());
       WebServer.Start(8080);
     }
     
     public override void ViewDidDisappear (bool animated)
     {
       base.ViewDidDisappear(animated);
       WebServer.Stop();
     }
