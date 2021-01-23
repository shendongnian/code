    Size last = new Size(0, 0);
    
    private void Me_Resize(object sender, System.EventArgs e)
    {
    	if (last != new Size(0, 0)) {
    		this.Parent.Size = Size.Add(this.Parent.Size, Size.Subtract(this.Size, last));
    	}
    	last = this.Size;
    }
