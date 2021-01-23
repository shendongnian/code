    public enum Gender
    {
       Male,
       Female
    }
    var userIds = 0;
    var testUsers = new Faker<User>()
        //Optional: Call for objects that have complex initialization
        .CustomInstantiator(f => new User(userIds++, f.Random.Replace("###-##-####")))
    
        //Basic rules using built-in generators
        .RuleFor(u => u.FirstName, f => f.Name.FirstName())
        .RuleFor(u => u.LastName, f => f.Name.LastName())
        .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
        .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
        .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
        //Use an enum outside scope.
        .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
        //Use a method outside scope.
        .RuleFor(u => u.CartId, f => Guid.NewGuid());
