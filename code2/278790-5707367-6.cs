    public class CreateDialogAction : TriggerAction<Hyperlink>
    {
    	public Type Type { get; set; }
    
    	protected override void Invoke(object parameter)
    	{
    		if (Type != null && Type.IsSubclassOf(typeof(Window)) && Type.GetConstructor(Type.EmptyTypes) != null)
    		{
    			Window window = Type.GetConstructor(Type.EmptyTypes).Invoke(null) as Window;
    			window.Show();
    		}
    	}
    }
