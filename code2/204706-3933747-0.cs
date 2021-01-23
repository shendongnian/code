    public partial class CapTextBox : UserControl
    {
    	public CapTextBox()
    	{
    		InitializeComponent();
    	}
    
    	private void textBox1_TextChanged(object sender, EventArgs e)
    	{
    		textBox1.Text = textBox1.Text.ToUpper();
    		textBox1.SelectionStart = textBox1.Text.Length;
    	}
    }
