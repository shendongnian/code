    private void FrmMain_Load(object sender, EventArgs e)
    {
    	this.ImgTop.Parent = this.ImgBottom;
    	this.ImgTop.BackColor = Color.Transparent;
    	this.ImgTop.BringToFront();
    	this.ChangeX.Value = 430;
    	this.ChangeY.Value = 15;
    
    	Point ptImageAtParent = new Point(this.ImgTop.Left + this.ImgBottom.Left, this.ImgTop.Top + this.ImgBottom.Top);
    	this.ImgTopCopy.Location = ptImageAtParent;
    	this.ImgTopCopy.SendToBack();
    }
