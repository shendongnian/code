[Column("Barcode", TypeName = "varchar(21)")]   
public string Barcode { get; set; }
Can you try this:
[Column(TypeName = "VARCHAR(21)")]
public string Barcode { get; set; }
Or you can specify in the Model Builder:
modelBuilder.Entity<BarCodeTipiDoc>()
            .Property(x=> x.BarCode)
            .HasColumnType("varchar(21)");
It would also help if you could post the model for your object `BarcodeTipiDoc`.
Update: Just saw that you were using EF Core. 
