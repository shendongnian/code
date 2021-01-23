        class Controller
        {
             readonly ITabView _view; 
             readonly IAsyncServiceReader _model;
             public Controller(ITabView view, IAsyncServiceReader model)
             {
                  _view = view; _model = model;
                  AttachHandlers();
             }
             void AttachHandlers()
             {
                  view.UserRequestedLoading += (sender,info) => model.Start(info);
                  model.DataReceived += (sender,data) => view.DisplayData(data);
             }
        }
