    public partial class Author : Window
    {
      private bool _isClicked;
      public bool IsClicked
      {
        get { return _isClicked; }
        set { _isClickedYes= value; }
      }
    
      public Author()
      {
        Mediator.Register("EnableIsClickedProperty", EnableIsClicked);
      }
    
      private void EnableIsClicked(object parameter)
      {
        _isClicked = dialogResult;
        
        // Assuming that AuthorViewModel is the DataContext of the Author view
        var viewModel = this.DataContext as AuthorViewModel;
        if (_isClicked && viewModel.DoCertainOperationCommand.CanExecute())
        {
          viewModel.DoCertainOperationCommand.Execute();
        }
      }
    }
