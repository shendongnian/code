    [Table(Name="#TmpTable1")]
    public class TmpRecord
    {
    	[Column(DbType="Int", IsPrimaryKey=true, UpdateCheck=UpdateCheck.Never)]
    	public int? Value { get; set; }   		
    }
    public Table<TmpRecord> TmpRecords
    {
     	get { return base.GetTable<TmpRecord>(); }
    }
    public void DropTable<T>()
    {
	    ExecuteCommand( "DROP TABLE " + Mapping.GetTable(typeof(T)).TableName  );
    }
		
    public void CreateTable<T>()
    {
	   ExecuteCommand(
		typeof(DataContext)
		.Assembly
		.GetType("System.Data.Linq.SqlClient.SqlBuilder")
		.InvokeMember("GetCreateTableCommand", 
	  	  BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod
	  	 , null, null, new[] { Mapping.GetTable(typeof(T)) } ) as string
		);	  	
    }
