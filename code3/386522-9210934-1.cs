    public partial class Window8 : Window
    {
      public static readonly DependencyProperty MyPersonProperty =
        DependencyProperty.Register("MyPerson",
                                    typeof(Person),
                                    typeof(Window8),
                                    new FrameworkPropertyMetadata(null, new PropertyChangedCallback(MyPersonPropertyChangedCallback)) {BindsTwoWayByDefault = true});
    
      private static void MyPersonPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e) {
        if (e.NewValue == null) {
          // ups, why is this null???
        }
      }
    
      public Person MyPerson {
        get { return (Person)this.GetValue(MyPersonProperty); }
        set { this.SetValue(MyPersonProperty, value); }
      }
    
      public Window8() {
        this.InitializeComponent();
        this.MyPerson = new Person();
      }
    
      private void Button_Click(object sender, RoutedEventArgs e) {
        // do something....
        this.MyPerson.FistName = "B";
        this.MyPerson.LastName = "BB";
      }
    }
