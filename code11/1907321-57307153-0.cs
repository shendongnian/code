    public class Project
        {
            public int ProjectID { get; set; }
            public string ProjectName{ get; set; }
            public string ProjectLocation{ get; set; }
            public  virtual List<People> ListOfPeople { get; set; }
        }
    public class People
        {
            public int Id{ get; set; }
            public string Name{ get; set; }
            public virtual Project project { get;set; }
        }
