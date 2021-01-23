    public partial class MainWindow : Window
    {
      public MainWindow()
      {
        InitializeComponent();
        DataObject.AddPastingHandler(tb, 
          new DataObjectPastingEventHandler(tb_Pasting));      
      }
      private void tb_Pasting(object sender, DataObjectPastingEventArgs e)
      {
        if (e.SourceDataObject.GetDataPresent(DataFormats.Text))
        {
          var text =
            (string)e.SourceDataObject.GetData(DataFormats.Text) ?? string.Empty;
          e.DataObject = new DataObject(DataFormats.Text, text.ToUpper());
        } 
      }
    }
