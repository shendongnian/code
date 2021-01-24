    public class AutoCompleteTextBox : Control
    { 
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
        "SelectedItem",
        typeof(object),
        typeof(AutoCompleteTextBox),
        new FrameworkPropertyMetadata(null, OnSelectedItemChanged));
    
      public object SelectedItem { get => (object)GetValue(AutoCompleteTextBox.SelectedItemProperty); set => SetValue(AutoCompleteTextBox.SelectedItemProperty, value);  }
    
      private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
        ...
      }
    
      private void Initialize()
      {
        AutoCompleteTextBox.OnSelectedItemChanged(this, new DependencyPropertyChangedEventArgs(AutoCompleteTextBox.SelectedItemProperty, this.SelectedItem, this.SelectedItem));
      }    
     
      public AutoCompleteTextBox()
      {
        InitializeComponent(); 
        this.Loaded  += () => Initialize();
      }
    }
