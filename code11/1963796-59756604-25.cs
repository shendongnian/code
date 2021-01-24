    public class Intermediary
    {
        public int IntermediaryID  { get; set; }
        public string RegisteredName { get; set; }
        public string TradingName { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
    
        public ICollection<Branch> Branches { get; set; }
    }
    
    public class Branch
    {
        public int BranchID { get; set; }
        public string Name { get; set; }
    
        // Generally Model classes should not have any idea on Display related stuff.
        // [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
    
        [StringLength(100)]
        // [DisplayName("Created By")]
        public string CreatedBy { get; set; }
    }
    
    public class IntermediaryViewModel
    {
        // I just created common expression so it can be used from Index as well as Details actions.
        // Feel free to remove this common expression and have the code inside controller actions if you prefer that way. 
        /// <summary>
    	/// Lambda expression converting Intermediary to IntermediaryViewModel
    	/// </summary>
    	public static readonly Expression<Func<Intermediary, IntermediaryViewModel>> AsIntermediaryViewModel =
    	i => new IntermediaryViewModel{
    		// Please add other required properties mapping here. I just showed couple 
    		IntermediaryID = i.IntermediaryID,
    		RegisteredName = i.RegisteredName,
            BranchID       = i.BranchID,
    		// if you want you can populate Branches (by Intermediary) here like this in a single database call as we have mentioned Include in actions
    		Branches = i.Branches.AsQueryable().Select(b => new BranchViewModel{ BranchID = b.BranchID}).ToList()
    	};
    	
        public int? IntermediaryID { get; set; }
    	
        [Required,StringLength(150),DisplayName("Registered Name")]
        public string RegisteredName { get; set; }
    
        [Required, StringLength(150), DisplayName("Registered Name")]
        public string TradingName { get; set; }
        public int Registration { get; set; }
        public int VATNumber { get; set; }
    
        [Required]
        public int FSPNumber { get; set; }
    
        // As now you have separate ViewModel for display purposes, 
    	// you can have string version of CreationDate which is (DateTime to string) converted as per your requirement.
        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
    
        [StringLength(100)]
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
        // Since you are defining BranchId as non-nullable, you will need to default to some existing BranchId so, your (create) view will show this branch when page is loaded. Otherwise make it nullable int (int ?) so, dropdown would display your message "Select Branch" when BranchId is null
        public int BranchID { get; set; }
        public ICollection<BranchViewModel> Branches { get; set; }
    }
    
    // since you are using Branches to populate drop down, other audit properties are not required here.
    // Does not hurt having them if you want.
    public class BranchViewModel
    {
    	public int BranchID { get; set; }
        public string Name { get; set; }	
    }
    
    		
    
    
    // GET: Intermediaries
    public async Task<IActionResult> Index()
    {
    	return View(await _context.Intermediaries.Include(i => i.Branches).Select(IntermediaryViewModel.AsIntermediaryViewModel).ToListAsync());
    }
    
    // GET: Intermediaries/Details/5
    public async Task<IActionResult> Details(int? id)
    {
    	if (id == null)
    	{
    		return NotFound();
    	}
        // I just renamed the variable to speak what it represents. 
    	var intermediaryViewModel = await _context.Intermediaries.Include(i => i.Branches).Select(IntermediaryViewModel.AsIntermediaryViewModel)
    		.FirstOrDefaultAsync(m => m.IntermediaryID == id);
    	if (intermediaryViewModel == null)
    	{
    		return NotFound();
    	}
    
    	return View(intermediaryViewModel);
    }
    private void PopulateBranchDropDownList(object selectedBranch = null)
    {
    	ViewBag.BranchList = from d in _context.Branch
    						orderby d.Name
    						select new BranchViewModel
    						{
    							BranchID = d.BranchID,
    							Name = d.Name
    						}.ToList();
        
        ViewBag.BranchID = selectedBranch;  //Set to some predefined BranchID selection, so when page is loaded, dropdown will be defaulted to this value.
    }
