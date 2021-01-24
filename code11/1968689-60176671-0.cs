    using System.Collections.ObjectModel;
    ....
    public ObservableCollection<int> PagesList
    {
      get
      {
        return (ObservableCollection<int>)GetValue ( PagesListProperty );
      }
      set
      {
        SetValue ( PagesListProperty, value );
      }
    }
    public static readonly DependencyProperty PagesListProperty = DependencyProperty.Register("PagesList", typeof(ObservableCollection<int>), typeof(CustomControl), new PropertyMetadata(null));
