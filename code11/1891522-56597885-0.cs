    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
            chart1.Series["S1"].Points.AddXY(0, 0, 10);
            chart1.Series["S1"].Points.AddXY(0, 0, 10);
    
        }
    
    }
   
    	Form chart1 = (Form)Application.OpenForms["Form1"];
    	//do here what you want
