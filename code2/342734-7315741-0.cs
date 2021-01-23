    private int count; 
    private ArrayList arrayctl = new ArrayList();
    private void button1_Click(object sender, System.EventArgs e) 
    { 
    	TextBox newtxt = new TextBox(); 
    	newtxt.Text = count.ToString(); 
    	count++; arrayctl.Add(newtxt); 
    	DrawControls(); 
    } 
    
    private void DrawControls() 
    { 
    	System.Drawing.Point CurrentPoint; CurrentPoint = panel1.AutoScrollPosition; 
    	int i = 0; 
    	panel1.Controls.Clear(); 
    	panel1.SuspendLayout(); 
    	foreach (TextBox txt in arrayctl) 
    	{
    	 panel1.Controls.Add(txt); 
    		txt.Width = panel1.ClientRectangle.Width; 
    		txt.Top = i; i += txt.Height; 
    	} 
    	panel1.ResumeLayout(); 
    	panel1.AutoScrollPosition = new Point(Math.Abs(panel1.AutoScrollPosition.X), Math.Abs(CurrentPoint.Y)); 
    }
