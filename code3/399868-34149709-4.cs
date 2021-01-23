    public static void ProjectionModel(ProjectionModelBuilder modelBuilder)
    {
		modelBuilder
		    .Projection<ClientDTO>()
		    .ForSource<Client>(configuration =>
		    {
		        configuration.Property(dto => dto.Name).ExtractFrom(entity => entity.Name);
			    // etc
			});
    }
