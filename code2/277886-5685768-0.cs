    namespace FormTest
    {
    	public partial class Form1 : Form
    	{
    		private Label PostAddedLabel;
    
    		public Form1()
    		{
    			InitializeComponent();
    			PostInitializeComponents();
    		}
    
      		private void PostInitializeComponents()
    		{
    			if (!this.DesignMode)
    			{
    				PostAddedLabel = new Label();
    				PostAddedLabel.Left = 100;
    				PostAddedLabel.Top = 30;
    				PostAddedLabel.Text = "The Post-added Label";
    
    				this.Controls.Add(PostAddedLabel);
    			}
    		}
    	}
    }
