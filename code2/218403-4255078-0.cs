    using (var context = new YourContext())
    {
        var class = new Class { Name = "Math" };
        class.Students.Add(new Student { Name = "Alice" });
        class.Students.Add(new Student { Name = "Bob" });
        context.AddToClasses(class);
        context.SaveChanges();
    }
