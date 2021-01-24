    namespace SecurityCore.Pages.SecurityLogs
    {
        public class IndexModel : PageModel
        {
            private readonly SecurityCore.Models.SecurityCoreContext _context;
            public IndexModel(SecurityCore.Models.SecurityCoreContext context)
            {
                _context = context;
            }
            public string EventDateSort { get; set; }
            public string EventStartSort { get; set; }
            public string EventEndSort { get; set; }
            public string ContactNameSort { get; set; }
            public string EventTypeSort { get; set; }
            public string ShiftRangeSort { get; set; }
        
            public string CurrentSort { get; set; }
            public string IDSort { get; set; }
        
            [DataType(DataType.Date)]
            public Nullable<DateTime> DateEnd { get; set; }
            [DataType(DataType.Date)]
            public Nullable<DateTime> DateBegin { get; set; }
            public Entity Entity { get; set; }
        
            public PaginatedList<SecurityLog> SecurityLog { get; set; }
            public List<secLog> SecurityLogOfficers { get; set; } = new List<secLog>();
            public List<string> OfficerLists { get; set; }
            [BindProperty]
            public OfficerList officerList { get; set; } = new OfficerList();
            [BindProperty]
            public List<string> OfficerIDs { get; set; } = new List<string>();
        
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex,
                                     string entitySelect, string entityFilter, DateTime dateBegin, DateTime dateBeginSelect, DateTime dateEnd, DateTime dateEndSelect)
        {
            selectedEntity = new SelectList(_context.Entity.Where(a => a.Active == "Y"), "Name", "Name");
                                   
            CurrentSort = sortOrder;
            IDSort = sortOrder == "ID" ? "ID_Desc" : "ID";
            EventDateSort = sortOrder == "EventDate" ? "EventDate_Desc" : "EventDate";
            ContactNameSort = sortOrder == "ContactName" ? "ContactName_Desc" : "ContactName";
            EventTypeSort = sortOrder == "EventType" ? "EventType_Desc" : "EventType";
            ShiftRangeSort = sortOrder == "ShiftRange" ? "ShiftRange_Desc" : "ShiftRange";            
            OfficerNameSort = sortOrder == "OfficerName" ? "OfficerName_Desc" : "OfficerName";
            IQueryable<SecurityLog> sort = from s in _context.SecurityLog select s;
            
            switch (sortOrder)
            {
                case "ID_Desc":
                    sort = sort.OrderByDescending(s => s.ID);
                    break;
                case "ID":
                    sort = sort.OrderBy(s => s.ID);
                    break;
                case "EventDate":
                    sort = sort.OrderBy(s => s.EventDate);
                    break;                
                case "ShiftRange":
                    sort = sort.OrderBy(s => s.ShiftRange.Name).ThenBy(s => s.EventDate);
                    break;
                case "ShiftRange_Desc":
                    sort = sort.OrderByDescending(s => s.ShiftRange.Name).ThenBy(s => s.EventDate);
                    break;
                case "EventType":
                    sort = sort.OrderBy(s => s.EventType.Name).ThenBy(s => s.EventDate);
                    break;
                case "EventType_Desc":
                    sort = sort.OrderByDescending(s => s.EventType.Name).ThenBy(s => s.EventDate);
                    break;                
                case "OfficerName":                    
                    sort = sort.OrderBy(s => officerList.ToString()).ThenBy(s => s.EventDate);
                    break;
                case "OfficerName_Desc":                    
                    sort = sort.OrderByDescending(s => officerList.ToString()).ThenBy(s => s.EventDate);
                    break;
                default:
                    sort = sort.OrderByDescending(s => s.EventDate);
                    break;
            }
            int pageSize = 5;
            
            SecurityLog = await PaginatedList<SecurityLog>.CreateAsync(sort
            .Include(a => a.Entity)
            .Include(b => b.EventType)
            .Include(c => c.Location)
            .Include(d => d.ShiftRange)
            .Include(e => e.Officer)                                    
            .AsNoTracking(), pageIndex ?? 1, pageSize);
            
            
            int rowID;
            rowID = 0;
            
            foreach (SecurityLog secLog in SecurityLog)
            {
                secLogCopy = secLog;
                OfficerLists = officerList.GetOfficerList(_context, secLog, rowID, OfficerIDs);
                if (!String.IsNullOrEmpty(searchString))
                {
                    sort = sort.Where(s => OfficerIDs.ToString().Contains(searchString));
                }
                rowID++;
            }
         
            if (!String.IsNullOrEmpty(searchString))
            {                                                
                sort = sort.Where(s => s.Narrative.Contains(searchString)
                                    || s.RecordLocked.Contains(searchString)
                                    || s.ContactName.Contains(searchString)
                                    || s.Location.Name.Contains(searchString)
                                    || s.EventType.Name.Contains(searchString)
                                    || s.ShiftRange.Name.Contains(searchString)
                                    || s.ID.ToString().Contains(searchString)
                                    || s.SubjectFirst.Contains(searchString)
                                    || s.SubjectLast.Contains(searchString));                                    
            }
         
        }
        
    }
