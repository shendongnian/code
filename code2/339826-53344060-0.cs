    public Form1()
    {
    	InitializeComponent();
    	toolTip1.SetToolTip(button1, "btn1");
    	toolTip1.SetToolTip(button2, "btn2");
    	toolTip1.SetToolTip(button3, "btn3");
    }
    
    
    private void button4_Click(object sender, EventArgs e)
    {
    	toolTip1.ToolTipTitle = textBox1.Text;
    }
