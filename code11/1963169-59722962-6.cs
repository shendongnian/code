    public class AddViewModel
    {
    	public AddViewModel()
    	{
    		this.LocList = new List<LocationViewModel>();
    	}
    
    	public int? LocId { get; set; }
        // Instead of LocationViewModel, you can go with your idea List<SelectListItem> and change controller action and view accordingly.
    	public List<LocationViewModel> LocList { get; set; }
    }
    
    public class LocationViewModel
    {
    	public int LocId { get; set; }
    	public string LocationName { get; set; }
    }
