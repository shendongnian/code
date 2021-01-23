    public partial class PlayerInfo : Form
    {
    	string caseID;
    	public Form2(string fmHomeCaseID)
    	{
    		caseID = fmHOmeCaseID;
    	}
    
    
    	// Button Click in your second form
    	private void button1_Click(object sender, EventArgs e)
    	{
    		textBox1.Text = caseID;
    	}
    }
