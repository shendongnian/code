    public partial class MyMessageBoxForm : Form {
    
      public static DialogResult Show(string message) {
        using (MyMessageBoxForm form = new MyMessageBoxForm(message)) {
          return form.ShowDialog();
        }
    
      private MyMessageBoxForm(string message) {
        // do something with message
      }
    
    }
