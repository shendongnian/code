    using System.Windows;
    using System.Windows.Controls.Primitives;
    
    namespace Foo
    {
      public partial class Window1
      {
        public Window1()
        {
          InitializeComponent();
        }
    
        private void OnClick(object sender, RoutedEventArgs e)
        {
          var bindingExpression = MyCheckBox.GetBindingExpression(ToggleButton.IsCheckedProperty);
          if (bindingExpression == null)
            MessageBox.Show("IsChecked property is not bound!");
        }
      }
    }
