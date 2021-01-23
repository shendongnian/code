    public class CustomButton : UIButton
    {
    			
        public CustomButton(RectangleF frame)
        {
    				
    	    this.Frame = frame;
    	    this.AddObserver(this, new NSString("Highlighted"), NSKeyValueObservingOptions.New, IntPtr.Zero);
    				
        }
    			
        public override void ObserveValue (NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
        {
    	    if (keyPath.ToString() == "Highlighted")
    	    {
    	        this.SetNeedsDisplay();
    	    }
        }
    	
        public override void Draw (RectangleF rect)
        {
    	    base.Draw (rect);
    				
    	    if (this.Highlighted)
    	    {
    	        // Draw for highlighted
    					
    	    } else
    	    {
    					
    	        // Draw for normal
    					
    	    }
        }
    			
    }
