    void MyOnMouseWheel(MouseEventArgs e)
    {
    	int ChangeIncrement = (this.panel1.VerticalScroll.SmallChange * 4); //Change the 4 to any positive number to scroll more or less one each scroll event.
    	if (e.Delta < 0)
    	{
    		int NewValue = this.panel1.VerticalScroll.Value + ChangeIncrement;
    		if (NewValue > this.panel1.VerticalScroll.Maximum)
    		{
    			this.panel1.VerticalScroll.Value = this.panel1.VerticalScroll.Maximum;
    		}
    		else
    		{
    			this.panel1.VerticalScroll.Value = NewValue;
    		}
    	}
    	else if (e.Delta > 0)
    	{
    		int NewValue = this.panel1.VerticalScroll.Value - ChangeIncrement;
    		if (NewValue < this.panel1.VerticalScroll.Minimum)
    		{
    			this.panel1.VerticalScroll.Value = this.panel1.VerticalScroll.Minimum;
    		}
    		else
    		{
    			this.panel1.VerticalScroll.Value = NewValue;
    		}
    	}
    	this.panel1.PerformLayout();
    }
