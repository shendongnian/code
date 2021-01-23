    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    	}
    	
    	private void Form1_Load(object sender, EventArgs e)
    	{
    		Action DoWork = new Action(CalcHere);
    		DoWork.BeginInvoke(new AsyncCallback(CallBack), null);
    	}
    
    	//Work here
    	private decimal myResult = 0;
    	private void CalcHere()
    	{
    		myResult = 5 + 5;
    	}
    
    	//callback here
    	private void CallBack(IAsyncResult result)
    	{
    		this.Invoke((Action)(() => { label1.Text = "Result: " + myResult.ToString(); }));
    	}
    }
