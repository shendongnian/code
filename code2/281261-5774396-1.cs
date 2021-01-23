    // Can has syntax highlighting? Hmm, guess not...
    public partial class MyUserControl3 : UserControl
    {
    	public static readonly DependencyProperty MarkersSourceProperty =
    			DependencyProperty.Register("MarkersSource",
    										typeof(ObservableCollection<Employee>),
    										typeof(MyUserControl3),
    										new UIPropertyMetadata(null));
    	public ObservableCollection<Employee> MarkersSource
    	{
    		get { return (ObservableCollection<Employee>)GetValue(MarkersSourceProperty); }
    		set { SetValue(MarkersSourceProperty, value); }
    	}
    
    	public MyUserControl3()
    	{
    		InitializeComponent();
    	}
    }
