    public static IQueryable<Person> WithName(this IQueryable<Person> value, 
                                              string name)
    {
        return value.Where(x => x.PersonDetails.Any(y => y.Name == name));
    }
