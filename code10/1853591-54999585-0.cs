    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    
    		for (int x = 0; x < 9; x++)
    		{
    			var button = new Button
    			{
    				Name = "Test-" + x,
    				Text = "Test-" + x,
    				Width = 100,
    				Height = 100
    			};
    
    			button.Click += OnButtonClick;
          flowLayoutPanel1.Controls.Add(button);
    		}
    	}
    
    	private void OnButtonClick(object sender, EventArgs e)
    	{
            //Instead of this...
    		//((Button)sender).Hide();
            //Do this...
    		var button = ((Button) sender);
    		button.FlatStyle = FlatStyle.Flat;
    		button.FlatAppearance.BorderColor = BackColor;
    		button.FlatAppearance.MouseOverBackColor = BackColor;
    		button.FlatAppearance.MouseDownBackColor = BackColor;
    		button.Text = string.Empty;
    		button.Enabled = false;
    	}
    }
