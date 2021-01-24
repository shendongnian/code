    public IActionResult GetPeople()
    {
        // WARNING: NEVER DO THIS!
        using( MyDbContext db = new MyDbContext( GetConnectionString() ) )
        {
            return this.Ok( db.People.Where( p => p.Name == "John Smith" ) );
            // or:
            return this.View( model: db.People.Where( p => p.Name == "John Smith" ) );
        }
    }
