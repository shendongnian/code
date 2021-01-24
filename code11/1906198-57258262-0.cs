builder.HasIndex(e => e.CreatedDate)
       .IsUnique();
builder.Property(e => e.CreatedDate)
       .HasColumnType("Date");
With data annotations
[Index(IsUnique=true)]
[Column(TypeName="Date")]
public DateTime CreatedDate { get; set; }
