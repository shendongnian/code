    public class EditViewModel
    {
        public int? FooType { get; set; }
        public IEnumerable<SelectListItem> GetFooTypes(object selectedFooType = null)
    	{
    		return new SelectList(repository.GetFooTypes(), "Id", "Value", selectedFooType);
    	}
    }
