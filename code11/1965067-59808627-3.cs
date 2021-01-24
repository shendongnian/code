    public class AuthorViewModel
    {
      public ICommand DoCertainOperationCommand => new RelayCommand(DoCertainOperation, CanExecuteDoCertainOperation);
    
      private void DoSomething()
      {
        //this will call the EnableIsClicked method in Author.xaml.cs
        Mediator.NotifyCollegue("EnableIsClickedProperty", null);
      }
    
      private void DoCertainOperation(object param)
      {
        // As this method is only invoked by the view when Author.IsClicked == true,
        // the view model doesn't need to care about the view's property states.
        // IsClicked is UI logic and belongs solely to the view.
      }
    
      private bool CanExecuteDoCertainOperation => true;
    }
