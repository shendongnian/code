        [Table("some_table")]
    	public class SomeEntity : IVersionedRow //define an interface as described previously
    	{
    		...
    		[Column("row_version")]
    		public long RowVersion { get; set; }
    	}
