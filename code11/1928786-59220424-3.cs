    JsonSerializerOptions options = new JsonSerializerOptions();
    options.SetupExtensions();
    DiscriminatorConventionRegistry registry = options.GetDiscriminatorConventionRegistry();
    registry.RegisterConvention(new AttributeBasedDiscriminatorConvention<string>(options, "Tag"));
    registry.RegisterType<Box>();
    registry.RegisterType<Circle>();
    
    Shape origin1 = new Box { Width = 10, Height = 20 };
    Shape origin2 = new Circle { Radius = 30 };
    
    string json1 = JsonSerializer.Serialize(origin1, options);
    string json2 = JsonSerializer.Serialize(origin2, options);
    
    Console.WriteLine(json1); // {"Tag":"Box","Width":10,"Height":20}
    Console.WriteLine(json2); // {"Tag":"Circle","Radius":30}
    
    var restored1 = JsonSerializer.Deserialize<Shape>(json1, options);
    var restored2 = JsonSerializer.Deserialize<Shape>(json2, options);
    
    Console.WriteLine(restored1); // Box: Width=10, Height=20
    Console.WriteLine(restored2); // Circle: Radius=30
