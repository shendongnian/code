    public partial class Window1 : Window
        {
    
            public Window1()
            {
                InitializeComponent();
    
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
               MainWindow.oc.Add(new oToevoegen { Name = "Name2" });  
            }
        }
