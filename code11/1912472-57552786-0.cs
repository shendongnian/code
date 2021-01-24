    namespace NugetDependecyTree.DependencyResolver.ViewModels
    {
       public class DependencyViewModel : ViewModelBase
       {
          ...
    
          private bool _isSelected;
          public bool IsSelected
          {
             get => _isSelected;
             set
             {
                if (value)
                {
                    // expand all parents up to root
                    DependencyTreeItemViewModel parent = Parent as DependencyTreeItemViewModel;
                    while (parent != null)
                    { 
                       parent.IsExpanded = true;
                       parent = parent.Parent as DependencyTreeItemViewModel;
                    }
                }
                _isSelected = value;
                OnPropertyChanged();
             }
          }
    
          ...
       }
    }
