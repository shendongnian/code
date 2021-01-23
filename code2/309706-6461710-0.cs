    var currentEmployees = new List<Employee>
    {
        new Employee { Skills = new List<string> { "Programming", "Troubleshooting" } },
        new Employee { Skills = new List<string> { "Accounting", "Finance" } },
    };
    var newHire = new Employee { Skills = new List<string> { "Programming", "Networking" } };
    var count = currentEmployees.Count(e => e.Skills.Any(newHire.Skills.Contains));
    // count == 1
