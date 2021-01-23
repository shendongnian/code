    public partial class X : FormManager
    {
    	public X()
    	{
    		InitializeComponent();
    	}
    
    	private void X_Load(object sender, EventArgs e)
    	{
    		this.BackgroundActionCompleted = delegate() { this.label2.Text = "New Text"; };
    	}
    }
