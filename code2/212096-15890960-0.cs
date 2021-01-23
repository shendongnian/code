    /// <summary>
    /// Deriving a new DataGrid because we need an event to tell us when editing is complete.
    /// </summary>
    public class DataGridMod : DataGrid
    {
       public delegate void EditCompletedDelegate();
       public EditCompletedDelegate EditCompleted;
    
       public DataGridMod() { }
    
       protected override void OnExecutedCommitEdit(ExecutedRoutedEventArgs e)
       {
          base.OnExecutedCommitEdit(e);
    
          if (EditCompleted != null)
             EditCompleted();
       }
    }
