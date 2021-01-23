    public partial class SampleDockableContent : DockableContent
    {
      public SampleDockableContent() {
        this.InitializeComponent();
        this.DataContext = this;
      }
    
      protected override bool CanExecuteCommand(ICommand command) {
        if (command == DockableContentCommands.ShowAsDocument) {
          if (this.DockableStyle == DockableStyle.DockableToBorders) {
            return false;
          }
          if (this.State == DockableContentState.Document) {
            return false;
          }
        }
        return base.CanExecuteCommand(command);
      }
    }
