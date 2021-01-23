    foreach (var per in people.OrderByMany(
                        new Tuple<Expression<Func<Person, object>>, SortOrder>(x => x.Age, SortOrder.Descending), 
                        new Tuple<Expression<Func<Person, object>>, SortOrder>(x => x.Name, SortOrder.Ascending)))
    {
        Console.WriteLine("{0} Age={1}", per.Name, per.Age);
    }
           
