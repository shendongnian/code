    private void InitializeComponent()
    {
    		lookInsideButton = new System.Windows.Forms.Button();
    		lookInsideButton.Click += new EventHandler(lookInsideButton_Click);
    
    		exitViewButton = new System.Windows.Forms.Button();
    		exitViewButton.Click += new EventHandler(exitViewButton_Click);
    }
    
    void lookInsideButton_Click(object sender, EventArgs e)
    {
    	ShowInsideView();
    }
    
    void exitViewButton_Click(object sender, EventArgs e)
    {
    	ExitInsideView();
    }
    
    System.Windows.Forms.Button lookInsideButton, exitViewButton;
