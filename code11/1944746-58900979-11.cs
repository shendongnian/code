    public partial class Presenter : INotifyPropertyChanged
    {
      public Presenter()
      {
        // Set default content
        this.SelectedContent = new StudentOverviewModel();
      }
      private object selectedContent;
      public object SelectedContent
      {
        get => this.selectedContent; 
        set
        { 
          this.selectedContent = value; 
          OnPropertyChanged();
        }
      }
   
      // Use ICommand implementation like DelegateCommand
      public ICommand LoadContentCommand => new LoadContentCommand(ExecuteLoadContent, CanExecuteLoadContent);
 
      private void ExecuteLoadContent(object param)
      {
        // Do something ...
        // Load the new content on Button clicked
        this.SelectedContent = new StudentAddModel();
      }
      private bool CanExecuteLoadContent => true;
    }
