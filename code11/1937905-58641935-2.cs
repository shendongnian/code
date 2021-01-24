    public Template Template { get; set; }
    instances.Aggregate()
        .Lookup("templates", "templateId", "_id", @as: "template")
        .Unwind("template")
        .As<Instance>()
        .ToList();
