        public partial class UserControl1 : UserControl
        {
           public delegate void ValueChangedEventHandler(object sender, EventArgs e);
           public event ValueChangedEventHandler ValueChanged;
           public UserControl1()
           {
               // Required to initialize variables
               InitializeComponent();
           }
           private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
           {
              if (ValueChanged != null)
              {
                  ValueChanged(this, EventArgs.Empty);
              }
           }
       }
