    public class MyControl : CompositeControl
    {
       //New public event declaration of type EventHandler
       public event EventHandler Submit_OnClick;
    			
       void btnSubmit_Click(object sender, EventArgs e)
       {
          //DO SOMETHING
          if (success)
          {
             //CALL DEVELOPER'S LOGIC
    
             //Code to raise the event only if there are subscribers.
    	     if (Submit_OnClick != null)
    	     {
    		   Submit_OnClick(this, new EventArgs());
    	     }
          }
       }
    }
