    [DelimitedRecord(",")] 
	public class Info
	{ 
		[FieldQuoted()] 
	    public string Code ;
		[FieldQuoted()] 
		public string Description ;
		[FieldQuoted()] 
		public string Packing ;	
		public decimal INV ;
		public decimal BO ;
		[FieldQuoted()] 
		public string Barcode ;
		public decimal Price ; 
		public decimal Disc ;
		public decimal Nett ;
	 
	} 
