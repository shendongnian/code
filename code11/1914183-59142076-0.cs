    public class MyFormsWindow: FormsWindow
    {
      protected override bool OnDeleteEvent(Event evnt)
      {
        var messageDialog = new MessageDialog(Program.MainWindow, DialogFlags.Modal, 
        MessageType.Question, ButtonsType.YesNo,
          "Do you want to exit?", String.Empty)
        {
          Title = "Confirmation",
        };
        int result = messageDialog.Run();
      
        //the magic numbers stand for "Close" and "No" results
        if (result == -4
          || result == -9
        {
          messageDialog.Destroy();
          return true; // true means not to handle the Delete event by further handlers, as result do not close application
        }
        else
        {
          messageDialog.Destroy();
          return base.OnDeleteEvent(evnt);
        }
      }
