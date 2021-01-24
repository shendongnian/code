[Column("Barcode", TypeName = "varchar(21)")]   
public string Barcode { get; set; }
Can you try this:
[Column(TypeName = "VARCHAR")]
[StringLength(21)]
public string Barcode { get; set; }
It would also help if you could post the model for your object `BarcodeTipiDoc`.
