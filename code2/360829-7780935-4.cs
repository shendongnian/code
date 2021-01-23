    var sb = new StringBuilder();
    using (var ctx = new Ctx())
    {
        ctx.CommandTimeout = 10000; // Perhaps not necessary anymore
        var allClasses = ctx.Classes.OrderBy(o => o.Id).ToList(); // <- No Include!
        foreach (var c in allClasses)
        {
            // "Explicite loading": This is a new roundtrip to the DB
            ctx.LoadProperty(c, "Students");
        }
        foreach (var c in allClasses)
        {
            // ... same code as above
        }
    }
    lblResult.Text = sb.ToString();
