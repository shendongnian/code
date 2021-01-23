    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Threading;
    namespace CircleMove
    {
    	/// <summary>
    	/// Description of MainForm.
    	/// </summary>
    	public partial class MainForm : Form
    	{
    		int x=0,y=0;
    		Thread t;
    	
    		public MainForm()
    		{
    			
    			//
    			// The InitializeComponent() call is required for Windows Forms designer support.
    			//
    			InitializeComponent();
    			
    			//
    			// TODO: Add constructor code after the InitializeComponent() call.
    			//
    		}
    		void MainFormPaint(object sender, PaintEventArgs e)
    		{
    			Graphics g=e.Graphics;
    			Pen p=new Pen(Color.Orange);
    			Brush b=new SolidBrush(Color.Red);
    		//	g.FillRectangle(b,0,0,100,100);
    			g.FillEllipse(b,x,y,100,100);
    		}
    		void MainFormLoad(object sender, EventArgs e)
    		{
    			t=new Thread(  new ThreadStart(
    						
    				()=>{
    					while(true)
    					{
    						Thread.Sleep(10);
    						x++;y++;
    						this.Invoke(new Action(
    							()=>{
    								
    								this.Refresh();
    								this.Invalidate();
    								this.DoubleBuffered=true;
    								}
    											)
    										);
    					}
    			     	}
    											)
    				
    						);
    			
    			t.Start();
    		}
    	}
    }
