    private void comboBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			// Override this function to draw items in the Color comboBox
			// Get the Graphics Object (aka. CDC or Device Context Object )
			// passed via the DrawItemEventArgs parameter
			Graphics g = e.Graphics ;
			// Get the bounding rectangle of the item currently being painted
			Rectangle r = e.Bounds ;
			if ( e.Index >= 0 ) 
			{
                Rectangle rd = r; 
				r.X = r.Right ; 
				// Get the brush object, at the specifid index in the colorArray
				SolidBrush b = (SolidBrush)colorArray[e.Index];
				// Fill a portion of the rectangle with the selected brush
                g.FillRectangle(b, rd);
				
				// Draw the rectangle
				e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2 ), r );
				if ( e.State == ( DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))
				{
					// if the item is not selected draw it with a different color
					e.Graphics.FillRectangle(new SolidBrush(Color.White) , r);
					e.DrawFocusRectangle();
				}
				else
				{
					// if the item is selected draw it with a different color
					e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue) , r);
					e.DrawFocusRectangle();
				}
			}
		}
