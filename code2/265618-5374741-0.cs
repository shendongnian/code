    class Foo
    {
        public string Title{get;set;}
        public string Description{get;set;}
    }
    public partial class CreatePackWindow : Window
    {
         private readonly Foo foo;
         public CreatePackWindow(Foo foo)
         {
             InitializeComponent();
             this.Foo = foo;
         }
    
         private void btnCreate_Click(object sender, RoutedEventArgs e)
         {
                foo.Title = tbPackName.Text;
                foo.Description = tbDescription.Text;
                this.DialogResult = true;
                Close();
     
         }
    }
