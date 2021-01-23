        [Table("some_table")]
    	public class SomeEntity : IVersionedRow //define an interface as described previously and replace int type to long
    	{
    		...
    		[Column("row_version")]
    		public long RowVersion { get; set; }
    	}
