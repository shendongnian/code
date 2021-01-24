    public partial class StudentView : Page
    {
      public static readonly DependencyProperty SelectedPageProperty = DependencyProperty.Register(
        "SelectedPage", 
        typeof(object), 
        typeof(StudentView));
      public object SelectedPage
      {
        get => (object) GetValue(SelectedPageProperty); 
        set => SetValue(IsSpinningProperty, value); 
      }
      public StudentView()
      {
        InitializeComponent();
        // This switches the view without disabling the button
        this.SelectedPage = new StudentOverviewModel();
        if (this.DataContext is Presenter presenter)
        {
          presenter.PropertyChanged += (object o, PropertyChangedEventArgs e) =>
          {
            // This switches the view without disabling the button
            this.SelectedPage = new StudentAddModel();               
          };
        }
      }
    }
