    public class BindableSelectionTextBox : TextBox
    {
      // Defines the dependency property as normal
      public static readonly DependencyProperty SelectedTextProperty = 
        DependencyProperty.RegisterAttached(SelectedText, typeof(string),    
          typeof(BindableSelectionTextBox),
          new FrameworkPropertyMetadata("", SelectedTextPropertyChanged));
    
      private static void SelectedTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
        var textBox = (TextBox)d;
        textBox.SelectedText = (string)e.NewValue;
      }
    
      public new string SelectedText
      {
        get { return (string)GetValue(SelectedTextProperty); }
        set 
        { 
          if(value != SelectedText) 
          {
             SetValue(SelectedTextProperty, value); 
          }
        }
       }
     
      public BindableSelectionTextBox()
      {
        SelectionChanged += OnSelectionChanged;
      }
    
      private void OnSelectionChanged(object sender, RoutedEventArgs e)
      {
        SelectedText = base.SelectedText;
      }
    }
 
