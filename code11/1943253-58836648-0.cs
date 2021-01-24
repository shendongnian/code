    public static IQueryable<PersonViewModel> SelectProperties(
        this IQueryable<PersonViewModel> personViewModels,
        string propertyNames = "Id,DisplayName,Upn") {
        var properties = propertyNames.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        var type = typeof(PersonViewModel);
        // p =>
        var parameter = Expression.Parameter(type, "p");
        // new PersonViewModel()
        var newViewModel = Expression.New(type);
        // create bindings
        var bindings = properties
            .Select(s => {
                // property
                var property = type.GetProperty(s);
                // original value 
                var propertyExpression = Expression.Property(parameter, property);
                // set value "Property = p.Property"
                return Expression.Bind(property, propertyExpression);
            }
        );
        // new PersonViewModel { Property1 = p.Property1, ... }
        var body = Expression.MemberInit(newViewModel, bindings);
        // p => new PersonViewModel { Property1 = p.Property1, ... }
        var lambda = Expression.Lambda<Func<PersonViewModel, PersonViewModel>>(body, parameter);
        return personViewModels.Select(lambda);
    }
