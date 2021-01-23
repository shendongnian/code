    private float GetTextWidth(string fontFace, float fontSize, string text)
    {
    	SizeF size = new SizeF();
    
    	Font font = new Font(fontFace, fontSize);
    	
    	//Using a Bitmap object for frame of reference in order to get to a Graphics object
    	using (Bitmap b = new Bitmap(1, 1))
    	{
    		//Graphics object allows string measurement
    		using (Graphics g = Graphics.FromImage(b))
    		{
                //change the units to inches
    			g.PageUnit = GraphicsUnit.Inch;
    			
                //Perform the measurement
    			size = g.MeasureString(text, font);
    		}
    	}
    
        //Print to console if you want 
    	//Console.WriteLine(size.Width);
    
    	return size.Width;
    }
