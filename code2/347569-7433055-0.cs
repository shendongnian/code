    public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                LoadXAMLMethod(); 
            }
    
            
            public void LoadXAMLMethod()
            {
                try
                {
                    StreamReader mysr = new StreamReader("Page1.xaml");
                    DependencyObject rootObject = XamlReader.Load(mysr.BaseStream) as DependencyObject;
                    
                    this.Content = rootObject;
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message.ToString());    
                }
            }
        }
    }
