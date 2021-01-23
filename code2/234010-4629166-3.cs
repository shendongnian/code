    public partial class MyForm : Window
    {
      private ViewModels.myConfigurationViewModel mcvm = new ViewModels.myConfigurationViewModel();
    
      public MyForm()
      {
        mcvm.LoadConfiguration();
        this.DataContext = mcvm;
      }
