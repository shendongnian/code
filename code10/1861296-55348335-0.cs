    public class FakeNavigationService : INavigationService //this interface is from MS eShopOnContainer project
    {
        private List<ViewModelBase> _viewModels = new List<ViewModel>();
        
        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase {
            //create viewModel object from DI container
            //var viewModel = ......
            _viewModels.Add(viewModel);
        }
    
        public ViewModelBase CurrentPageViewModel {
            get {
                if (_viewModels.Count() < 1) {
                    return null;
                }
                return _viewModels[_viewModels.Count() - 1];
            }
        }
    }
