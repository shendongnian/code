    		this.cursorTool1.Pen.Width = 2;
    
            tChart1.MouseUp += TChart1_MouseUp;
    
    
    
      this.cursorTool2.Pen.Color = Color.Plum;
    		this.cursorTool2.Pen.Style = System.Drawing.Drawing2D.DashStyle.Dot; 
    		this.cursorTool2.Pen.Width = 2;
    
    	}
    
        private void TChart1_MouseUp(object sender, MouseEventArgs e)
        {
            var clicked = cursorTool1.Clicked(e.X, e.Y);
            if(clicked == Tools.CursorClicked.Vertical) 
            {
                MessageBox.Show("The Cursed has been released!");
            }
        }
