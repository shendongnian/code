        var template = new RazorTemplate {
            Model = new[] { 
                new {Name = "Scott", Id = 1},
                new {Name = "Steve", Id = 2},
                new {Name = "Phil", Id = 3},
                new {Name = "David", Id = 4}
            }
        };
        Console.WriteLine(template.TransformText());
