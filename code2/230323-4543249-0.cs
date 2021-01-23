    public class ButtonColumnTemplate : ITemplate
    {
    
    	private string id = "";
    
    	public ButtonColumnTemplate()
    	{
    	}
    
    	public ButtonColumnTemplate(string id)
    	{
    		this.id = id;
    	}
    
    	public void InstantiateIn(Control container) 
    	{ 
    		Button button = new Button();
    		button.ID = id;
    		container.Controls.Add(button); 
    	} 
    }
