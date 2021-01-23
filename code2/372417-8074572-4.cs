    using System;
    using System.Windows.Forms;
    
    namespace SO_Suffix
    {
    	public partial class Form2 : Form
    	{
            //<  The delegate needs to be defined as public in the form that 
            //<  is raising the event...
    		public delegate void ButtonClickedOnForm2 (object sender, EventArgs e); 
    		
    		public Form2()
    		{
    			InitializeComponent();
                this.button1.Click += new System.EventHandler(this.Button1_Click);
    		}
    		
                //<  Capture the click event from the button on Form2, and raise an event
    		void Button1_Click(object sender, EventArgs e)
    		{
    			ButtonClicked(this, e);
    		}
    		
    		public event ButtonClickedOnForm2 ButtonClicked;
    	}
    }
