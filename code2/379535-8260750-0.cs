    using System.Windows.Forms;
    using System.Threading;
    using System;
    
    namespace Threads
    {
    	public partial class Form1 : Form
    	{
    		public event EventHandler OnSomethingFinishes;
    
    
    		public Form1()
    		{
    			InitializeComponent();
    
    			OnSomethingFinishes += new EventHandler(Form1_OnSomethingFinishes);
    		}
        
    		void Form1_OnSomethingFinishes(object sender, EventArgs e)
    		{
    			this.Invoke(new EventHandler(Form1_OnSomethingFinishesSafe), sender, e);
    		}
        
    		void Form1_OnSomethingFinishesSafe(object sender, EventArgs e)
    		{
    			this.Text = "Done!";
    		}
        
    		private void BlockingFunction(object a_oParameter)
    		{
    			// Do something that blocks
    			Thread.Sleep(2000);
        
    			if (OnSomethingFinishes != null)
    				OnSomethingFinishes(this, null);
    		}
    
    		private void button1_Click(object sender, EventArgs e)
    		{
    			Thread l_oThread = new Thread(BlockingFunction);
    			l_oThread.Start();
    
    			this.Text = "Please Wait...";
    		}
    	}
    }
