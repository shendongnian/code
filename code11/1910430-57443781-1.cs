    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace ImageOverlap
    {
    	public partial class FrmMain : Form
    	{
    		public FrmMain()
    		{
    			InitializeComponent();
    		}
    
    		private void FrmMain_Load(object sender, EventArgs e)
    		{
    			this.ImgTop.Parent = this.ImgBottom;
    			this.ImgTop.BackColor = Color.Transparent;
    			this.ImgTop.BringToFront();
    			this.ChangeX.Value = 430;
    			this.ChangeY.Value = 15;
    		}
    
    		private void ChangeX_ValueChanged(object sender, EventArgs e)
    		{
    			this.SetOverlayImageLocation((int)this.ChangeX.Value, this.ImgTop.Top);
    		}
    
    		private void ChangeY_ValueChanged(object sender, EventArgs e)
    		{
    			this.SetOverlayImageLocation(this.ImgTop.Left, (int)this.ChangeY.Value);
    		}
    
    		private void SetOverlayImageLocation(int newX, int newY)
    		{
    			this.ImgTop.Left = newX;
    			this.ImgTop.Top = newY;
    			Point ptImageAtParent = new Point(this.ImgTop.Left + this.ImgBottom.Left, this.ImgTop.Top + this.ImgBottom.Top);
    			this.ImgTopCopy.Location = ptImageAtParent;
    			this.ImgTopCopy.SendToBack();
    		}
    	}
    }
