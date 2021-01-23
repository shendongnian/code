        using (var context = new TRANSITEntities())
        {
            var result = context.Table1.Where(c => c.UserCode == "123");
        }
        // throws exception:
        var array = result.ToArray();
