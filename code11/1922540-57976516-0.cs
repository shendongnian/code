    // Model class
    public class SomeModel
    {
    	public string GetString() 
    	{
    		return "Hi string";
    	}
    }
    
    // The view (first line)
    @model SomeModel   
    // Script portion of the view
    <script> let str = @Model.GetString(); </script>
    
