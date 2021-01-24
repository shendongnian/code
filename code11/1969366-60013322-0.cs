    public class ImageTemplateSelector : DataTemplateSelector
    {
    	public DataTemplate NormalTemplate { get; set; }
    	public DataTemplate SpecialTemplate { get; set; }
    
    	protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    	{
    		if (item is null) return NormalTemplate;
    
    		if (item is myImage image)
    		{
    			if (image.Type == "type1")
    				return SpecialTemplate;
    			else
    				return NormalTemplate;
    		}
    		else
    			throw new ArgumentException(nameof(ImageTemplateSelector));
    	}
    }
    
    
