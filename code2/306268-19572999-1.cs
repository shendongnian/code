        private void splitContainer2_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
		/* All you really need is this:
                    splitContainer1.SplitterDistance += e.X;  
			
		Note: Splitter distance must be a positive integer and e.X will be negitive when dragging to the left of the splitContainer. You could handel this check here or on the splitterMoving event.
				
			The code I have below shows how to “snap” a panel closed if the splitter is moved close enough to the edge 
		Or prevent a panel from being hidden from view (which could also be accomplished by setting the minimum size of a panel). 
		*/
                if (e.X + splitContainer1.SplitterDistance < 40)
                {
                   while (splitContainer1.SplitterDistance > 1)
                        splitContainer1.SplitterDistance--;
                    splitContainer1.Panel1Collapsed = true;
                }
                else if ((e.X + splitContainer1.SplitterDistance) * 1.00 / this.Width * 1.00 < .75)
                    splitContainer1.SplitterDistance += e.X;  
                else
                    Cursor.Current = Cursors.No;
               
               
            }
    }
