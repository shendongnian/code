    public Whatever GetAllByAge<T>(int age,
                                   Expression<Func<Person, T>> orderBy = null)
    {
        orderBy = orderBy ?? (Expression<Func<Person, T>>) 
                             (Expression<Func<Person, int>>)(e => e.Id);
        ...
    }
