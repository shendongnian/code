    [System.Data.Linq.Mapping.Table(Name = "book")]
    public class book
    { 
         [System.Data.Linq.Mapping.Column(Name = "ID", IsPrimaryKey = true)]
         public long ID   { get; set; }  //   
    	  
         [System.Data.Linq.Mapping.Column(Name = "Title", IsPrimaryKey = false)]
         public String Title   { get; set; }  // Book Title  
    	 
    }
