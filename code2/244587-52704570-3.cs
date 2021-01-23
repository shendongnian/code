    [Fact]
    public void AddSelectTest()
    {
        var data = new[]
        {
            new {Id = 01, Name = "Engineering", GroupName = "Engineering and Development"},
            new {Id = 02, Name = "Tool Design", GroupName = "Tool Design and Research"},
            new {Id = 03, Name = "Sales", GroupName = "Sales and Marketing"},
            new {Id = 04, Name = "Marketing", GroupName = "Marketing and Sales"},
            new {Id = 05, Name = "Purchasing", GroupName = "Inventory Management"},
            new {Id = 06, Name = "Research and Development", GroupName = "Development and Research"},
            new {Id = 07, Name = "Production", GroupName = "Manufacturing and Production"},
            new {Id = 08, Name = "Production Control", GroupName = "Control and Production"},
            new {Id = 09, Name = "Human Resources", GroupName = "Human Resources and Administration"},
            new {Id = 10, Name = "Finance", GroupName = "Finance and Executive General"},
            new {Id = 11, Name = "Information Services", GroupName = "Information Services and Administration"},
            new {Id = 12, Name = "Document Control", GroupName = "Document Control and Quality Assurance"},
            new {Id = 13, Name = "Quality Assurance", GroupName = "Administration and Quality Assurance"},
            new {Id = 14, Name = "Facilities and Maintenance", GroupName = "Maintenance and Facilities"},
            new {Id = 15, Name = "Shipping and Receiving", GroupName = "Receiving and Shipping"},
            new {Id = 16, Name = "Executive", GroupName = "Executive General and Administration"}
        };
        var queryable = data.AsQueryable();
        var first = queryable.Select(d => new { Id = d.Id, Name = d.Name }).FirstOrDefault(d => d.ToJson().FromJson<Department>().Id == 1);
        Assert.True(first != null, "Expected a department value but 'null' was found.");
    }
