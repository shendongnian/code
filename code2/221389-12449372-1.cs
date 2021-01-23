    static void Main()
    {
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
                  
    IDocumotiveCaptureView view = new DocumotiveCaptureView();
    IDocumentModel model = new DocumentModel();
    IDocumotiveCapturePresenter Presenter = new DocumotiveCapturePresenter(view, model);
    IControlsPresenter ControlsPresenter = new ControlsPresenter(view.ControlsView, model);
    IDocumentPresenter DocumentPresenter = new DocumentPresenter(view.DocumentView, model);
    //If we need to initialise any views, we can do it here via the view's presenter
    //The presenter must be exposed as a property, and contain an appropriate method (e.g. InitView())
    //Example call:  view.Presenter.InitView();
    Application.Run((Form)view);                                                         
    }
