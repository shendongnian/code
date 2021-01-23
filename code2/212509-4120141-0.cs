    Class Factory{
    
      Repository _repository;
    
      public Factory(Repository repository){
        _repository = repository;
      }
    
      public ViewModel GetViewModel(){
        var viewModel = new ViewModel();
        viewModel.MenuLinks = _repository.GetMenuLinks();
        return viewModel;
      }
    
    }
