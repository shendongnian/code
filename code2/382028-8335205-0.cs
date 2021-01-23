    public partial class MyView : UserControl
    {
    	public MyView()
    	{
    		InitializeComponent();
    		DataContext = new BookViewModel();
    	}
    }
