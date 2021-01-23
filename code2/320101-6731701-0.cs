    namespace WpfApplication1 {   
    /// <summary>     
    /// Interaction logic for Window1.xaml  
    /// </summary>  
    ///
    public partial class Window1 : Window  
    {
         string fixedItem;
          public Window1()
         {
             InitializeComponent();
             listBox1.ItemContainerGenerator.ItemsChanged += new System.Windows.Controls.Primitives.ItemsChangedEventHandler(list_changes);
          }
            private void list_changes(object sender, System.Windows.Controls.Primitives.ItemsChangedEventArgs e)
         {
             listBox1.UpdateLayout();
             listBox1.ScrollIntoView(fixedItem); 
        }
         // REST OF YOUR CODE...
