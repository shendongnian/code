    static void Main()
    {
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
                  
    IDocumotiveCaptureView view = new DocumotiveCaptureView();
    IDocumentModel model = new DocumentModel();
    IDocumotiveCapturePresenter Presenter = new DocumotiveCapturePresenter(view, model);
    IControlsPresenter ControlsPresenter = new ControlsPresenter(view.ControlsView, model);
    IDocumentPresenter DocumentPresenter = new DocumentPresenter(view.DocumentView, model);
    Application.Run((Form)view);                                                         
    }
