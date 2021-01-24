        var config = new MapperConfiguration(cfg => cfg.CreateMap<RequestModel, RequestDto>().ReverseMap());
        var mapper = config.CreateMapper();
        
        var source = new RequestDto
        {
            Id = 1,
            SubmittedById = 100,
            SubmittedByName = "User 100",
            Description = "Item 1",
            Location = "Location 1"
        };
        
        Console.WriteLine($"Name (original): {source.SubmittedByName}");
        var destination = mapper.Map<RequestDto, RequestModel>(source);
        Console.WriteLine($"Name (intermediate): {source.SubmittedByName}");
        source = mapper.Map<RequestModel, RequestDto>(destination, source);
        Console.WriteLine($"Name (final): {source.SubmittedByName}");
