            class ABC
            {
                public string Name { get; set; }
            }
            var p = Expression.Parameter(typeof(ABC));
            var prop = Expression.Property(p, "Name");
            var body = Expression.Equal(prop, Expression.Constant("Bob"));
            var exp = Expression.Lambda(body, p);
            var func = (Func<ABC, bool>)exp.Compile();
            ABC[] items = "Fred,Bob,Mary,Jane,Bob".Split(',').Select(s => new ABC() { Name = s }).ToArray();
            ABC[] bobs = items.Where(func).ToArray();
