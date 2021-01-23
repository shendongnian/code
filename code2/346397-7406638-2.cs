    //Child form declaration
    
    public class CommercialOfferEditProperties:Form
    {
    
    public event EventHandler ButtonClicked;
    
    public void NotifyButtonClicked(EventArgs e)
    {
           if(ButtonClicked != null)
           ButtonClicked(this,e);
    
    }
    
    ...
    
    }
