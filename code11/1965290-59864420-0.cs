    public partial class Form2 : Form
    {
    	SerialPort sp;
    
    	public Form2()
    	{
    		InitializeComponent();
    	}
    
    	private void buttonOpen_Click(object sender, EventArgs e)
    	{
    		sp = new SerialPort("COM1", 9600);  //initialize our serial port
    		sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived); //create our data received event
    		sp.Open(); //Open the port
    	}
    
    	void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    	{
    		string Data = sp.ReadExisting();
    
    		Console.Write(Data);
    	}
    
    	private void buttonClose_Click(object sender, EventArgs e)
    	{
    		sp.Close(); //close the port
    	}
    }
