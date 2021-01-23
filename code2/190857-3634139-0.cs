    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    		}
    
    		private List<string> GetStuff()
    		{
    			List<string> stuff = new List<string>();
    
    			stuff.Add("foo");
    			stuff.Add("bar");
    			stuff.Add("baz");
    
    			return stuff;
    		}
    
    		private void FillWithStuff(TextBoxBase textBox)
    		{
    			List<string> stuff = GetStuff();
    
    			foreach (string s in stuff)
    			{
    				textBox.Text += s + "\r\n";
    			}
    		}
    
    		private void button1_Click(object sender, EventArgs e)
    		{
    			FillWithStuff(richTextBox1);
    		}
    	}
    }
