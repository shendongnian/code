    public partial class MyDialogWindow: Window
    {
        public string SelectedItem
        {
            get;
            set;
        {
        
        // etc...
    }
    MyDialogWindow dialog = new MyDialogWindow(result);
    if (form.ShowDialog().Value)
    {
       string res = dialog.SelectedItem;
    }
