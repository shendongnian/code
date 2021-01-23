    public class EditViewModel
    {
        public int? FooType { get; set; }
        public IEnumerable<int?> FooTypes
    	{
    		get
    		{
    		    // declare/define repository in your model somewhere	
                return repository.GetFooTypes();
    		}
    	}
    }
