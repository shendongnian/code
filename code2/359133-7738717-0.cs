    public class ApplicationController
    {
    
       private IDictionary<string, Tuple<Func<ISubView>, Func<ViewModel>> _registry;
       private Func<IShellWindow> _shellActivator;
    
       public ApplicationController(Func<IShellWindow> shellActivator)
       {
          _registry = new Dictionary<string, Tuple<Func<ISubView>, Func<ViewModel>>();
          _shellActivator = shellActivator;
       }
    
       public void RequestShow(string viewName)
       {
          var shell = _shellActivator(); 
          var viewToModel = _registry[viewName];
          var view = viewToModel.Item1();
          var viewModel = viewToModel.Item2();
          view.ViewModel = viewModel;
          shell.Display(view);
       }
    
       public Register(string name, Func<ISubView> subViewCreator, Func<ViewModel> viewModelCreator)
       {
          _registry.Add(name, new Tuple(subViewCreator, viewModelCreator));
       }
    }
