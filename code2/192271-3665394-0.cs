    protected override void OnPaint(PaintEventArgs e) {
		base.OnPaint(e);
        //_backBuffer = new Bitmap(this.Width, this.Height);
        Graphics g = Graphics.FromImage(_backBuffer);
		
		//Rest of your code
		//e.Graphics.DrawImageUnscaled(_backBuffer, 0, 0);
        //g.Dispose();
        //e.Dispose();
        //base.OnPaint(e);
        //_backBuffer.Dispose();
        //_backBuffer = null;
    }
