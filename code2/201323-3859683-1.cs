    public void Grow(int heightToGrow)
    { 
      height += heightToGrow; 
    } 
    public virtual void btnGrowClicked (object sender, EventArgs args) 
    { 
      txtGrowBy.Text = this.heightToGrow; 
    }
