    public partial class MyView : Window
    {
         private MyViewModel aModel;
    
         public MyView()
         {
             InitializeComponent();
             aModel = new MyViewModel();
             this.DataContext = aModel();
    }
