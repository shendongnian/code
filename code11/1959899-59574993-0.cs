    public List<SelectListItem> ProjectList { get; set; }
    public void OnGet()
    {
          ProjectList = GetProjectList().Select(p => new SelectListItem
          {
                Value=p.Id.ToString(),
                Text=p.Name
          }).ToList();
    }
    public IEnumerable<Projects> GetProjectList()
    {
          var  projects = objProject.GetAllProjects().ToList();
          return projects;
    }
