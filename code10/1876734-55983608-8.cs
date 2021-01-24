    public class MainViewModel : ViewModelBase
    {
        public ActionExecutorCollectionViewModel ActionExecutors { /* INPC stuff */ }
            //  ViewModels create their own children. 
            = new ActionExecutorCollectionViewModel();
    }
    public class ActionExecutorCollectionViewModel : ViewModelBase
    {
        public ObservableCollection<ActionExecutor> Items { /* INPC stuff */ }
        public ActionExecutor NewActionExecutor { /* INPC stuff */ }
        // Create new ActionExecutor and assign to NewActionExecutor 
        public ICommand CreateActionExecutor { /* ... */ }
        // Add NewActionExecutor to Items and set NewActionExecutor to null 
        public ICommand SaveActionExecutor { /* ... */ }
    }
