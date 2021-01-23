    [Table(Name = "mydb.dbo.myTable")]
    public class MyTable 
    {
	    [Column(Name = "Id", IsPrimaryKey = true)]
    	public int Id { get; set; }
	    
    	[Column(Name = "ActiveDate")]
	    public DateTime? ActiveDate { get; set; }
    	   
    }
	
