    public class DialogManager
    {
      private int _numberOfOpenDialogs;
      public event EventHandler AllDialogsClosed;
      public ShowDialog(object dialogInstance)
	  {
          _numberOfOpenDialogs++;
      }
      public CloseDialog(object dialogInstance)
      {
          _numberOfOpenDialogs--;
  
          if (_numberOfOpenDialogs == 0)
          {
              OnAllDialogsClosed();
          }
      }
      protected virtual void OnAllDialogsClosed(EventArgs e)
      {
        EventHandler handler = AllDialogsClosed;
        if (handler != null)
        {
            handler(this, e);
        }
      } 
    }
