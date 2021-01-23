    public Form1()
    {
    	InitializeComponent();
    	button4.HandleDestroyed += new EventHandler(button4_HandleDestroyed);
    	button4.Disposed += new EventHandler(button4_Disposed);
    }
    
    void button4_Disposed(object sender, EventArgs e)
    {
    	MessageBox.Show("Disposed");
    }
    
    void button4_HandleDestroyed(object sender, EventArgs e)
    {
    	MessageBox.Show("HandleDestroyed");
    }
