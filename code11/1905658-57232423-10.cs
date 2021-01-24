    public class LowLevelController : ChildController
    {
        private class I2C
        {
    	   private LowLevelController _parent;
           public I2C(LowLevelController parent)
           {
    		  _parent = parent;
           }
    			
    	   public void RunBase()
    	   {
    		  _parent.Run();
    	   }
        }
    
         public void Computate()
         {
             var i2c = new I2C(this);
    		 i2c.RunBase();
         }
    }
