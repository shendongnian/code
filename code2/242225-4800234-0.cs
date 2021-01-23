    [Column]
    [DisplayName("Department")]
    [Required(ErrorMessage = "Please select a department")]
    public int DepartmentID { get; set; }
    private EntityRef<Department> department;
  
    [Association(IsForeignKey = true, ThisKey = "DepartmentId"]
    public Department Department 
    { 
        get { return department.Entity; }
        set { department.Entity = value; }
    }
