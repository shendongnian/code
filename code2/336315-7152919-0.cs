    public class ViewConfirmationDialogService : IConfirmationDialogService
    {
       public string Caption { get; set; }
       public bool Show(string question)
       {
          return MessageBox.Show(
             string question, 
             Caption, 
             MessageBoxButtons.YesNo,
             MessageBoxImage.Question) == MessageBoxResult.Yes;
       }
    }
