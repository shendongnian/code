    public class MyClass
    {
    	Font _normalFont;
    	Font _boldFont;
    	
        public MyClass() : IDisposble
    	{
    		try
    		{
    			_normalFont = new Font("Arial", 9);
    			_boldFont = new Font("Arial", 9, FontStyle.Bold);
    		}
    		catch
    		{
    			//error handling
    		}
    		
    		label1.MouseEnter += label1_MouseEnter;
    		label1.MouseLeave += label1_MouseLeave;
    	}
    	
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            var font = ((Label)sender).Font;
        
            ((Label)sender).Font = new Font(font, FontStyle.Bold);
        
            font.Dispose();
        }
    
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            var font = ((Label)sender).Font;
        
            ((Label)sender).Font = new Font(font, FontStyle.Regular);
        
            font.Dispose();
        }
    	
    	public void Dispose()
    	{
    		label1.MouseEnter -= label1_MouseEnter;
    		label1.MouseLeave -= label1_MouseLeave;
    		
    		if(_normalFont != null)
    		{
    			_normalFont.Dispose();
    		}
    		
    		if(_boldFont != null)
    		{
    			_boldFont.Dispose();
    		}
    	}
    }
