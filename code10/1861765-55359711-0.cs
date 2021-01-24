    public class DepartmentActivity
        {
            #region Public properties
    
            public int ActivityId{ get; set; }
            public int DepartmentId{ get; set; }
            public string DisplayOrder {get;set;} // this can be whatever you like and add more properties if needed
    
            #endregion
    
            #region Relations
    
            public Activity Activity{ get; set; }
            public Department Department { get; set; }
    
            #endregion
        }
