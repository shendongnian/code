    public async Task<IActionResult> GetPeople()
    {
        using( MyDbContext db = new MyDbContext( GetConnectionString() ) )
        {
            List<Person> list = await db.People
                .Where( p => p.Name == "John Smith" )
                .ToListAsync();
            // WebAPI:
            return this.Ok( list ); // returning an evaluated list, loaded into memory. (Make sure Lazy Navigation Properties are disabled too)
            // MVC:
            PeopleListViewModel vm = new PeopleListViewModel(); // in MVC always use a custom class for root view-models so you're not accepting nor returning Entity Framework entity types directly
            vm.List = list;
            return this.View( vm );
        }
    }
