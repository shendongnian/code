    namespace ParentToChildWindow    
    {
    
        using System.Windows;   
        using System.Windows.Controls;
    
        public partial class ChildWindowControl : ChildWindow    
        {
    
            public int Value { get; set; }    
            public string Name { get; set; }
    
            public ChildWindowControl()    
            {   
                InitializeComponent();
    
            }    
            private void OKButton_Click(object sender, RoutedEventArgs e)    
            {
    
                this.txtValue.Text = this.Value.ToString();    
                this.txtName.Text = this.Name;    
            }
            private void CancelButton_Click(object sender, RoutedEventArgs e)    
            {
                    this.DialogResult = false;
    
            }
    
        }
    
    }
