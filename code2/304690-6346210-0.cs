    namespace Demo1
    {
    	public partial class BillingInfoHeaderControl : UserControl
    	{
    		public BillingInfoHeaderControl()
    		{
    			InitializeComponent();
    			this.DataContext = new BillingInfoHeaderControlVM();
    		}
    
    		public int ProjectId
    		{
    			get { return (int)GetValue(ProjectIdProperty); }
    			set { SetValue(ProjectIdProperty, value); }
    		}
    
    		public static readonly DependencyProperty ProjectIdProperty =
    			DependencyProperty.Register("ProjectId", typeof(int), typeof(BillingInfoHeaderControl),
    			  new PropertyMetadata(0));
    		
    	}
    }
    namespace Demo1
    {
    	public class BillingInfoHeaderControlVM : INotifyPropertyChanged
    	{
    		private int _projectId;
    		public int ProjectId
    		{
    			get { return _projectId; }
    			set
    			{
    				if (_projectId != value)
    				{
    					_projectId = value;
    					if (PropertyChanged != null)
    					{
    						PropertyChanged(this, new PropertyChangedEventArgs("ProjectId"));
    					}
    				}
    			}
    		}
    
    		public event PropertyChangedEventHandler PropertyChanged;
    	}
    }
