    public partial class StudentView : Page
    {
      public static readonly DependencyProperty SelectedContentProperty = DependencyProperty.Register(
        "SelectedContent", 
        typeof(object), 
        typeof(StudentView));
      public object SelectedContent
      {
        get => GetValue(SelectedContentProperty); 
        set => SetValue(SelectedContentProperty, value); 
      }
      public StudentView()
      {
        InitializeComponent();
        // This switches the view without disabling the button
        this.SelectedContent = new StudentOverviewModel();
        if (this.DataContext is Presenter presenter)
        {
          presenter.PropertyChanged += (object o, PropertyChangedEventArgs e) =>
          {
            // This switches the view without disabling the button
            this.SelectedContent = new StudentAddModel();               
          };
        }
      }
    }
