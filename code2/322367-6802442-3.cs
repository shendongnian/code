    Project[] projects = Project.Load(filename).ToArray();
    
    foreach(Project project in projects)
    {
        Console.WriteLine("Project: " + project.Name);
        Console.WriteLine("TestCycle: " + project.TestCycle.Number.ToString());
        Console.WriteLine("Files:");
        foreach(FileHash file in project.TestCycle.Files)
            Console.WriteLine(string.Format("    Name: {0}, HashCode: {1}", file.Name, file.HashCode));
    }
