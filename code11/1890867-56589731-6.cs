    public class Document
    {
    	public string BaseUniqueID { get; set; }
    	public int? Weight { get; set; }
    	public DateTime DocumentDate { get; set; }
    	public Description Description { get; set; }
    	public int DocumentType_Id { get; set; }
    }
	var indexResponse = client.CreateIndex("your_index", c => c
		.Mappings(m => m
			.Map<Document>(mm => mm
				.AutoMap()
				.Properties(p => p
					.Object<Description>(o => o
						.Name(n => n.Description)
						.AutoMap()
						.Properties(pp => pp
                            .Text(t => t.Name(n => n.Standard).Analyzer("standard"))
							.Text(t => t.Name(n => n.English).Analyzer("english"))
							.Text(t => t.Name(n => n.NoFaPersian).Analyzer("nofapersian"))
							.Text(t => t.Name(n => n.French).Analyzer("french"))
						)
					)
				)
			)
		)		
	);
