    public void UpdatePerson(UpdatePersonViewModel updatePersonModel)
    {
        if (updatePersonModel == null)
           throw new ArgumentNullException("updatePersionModel");
    
        // TODO: Validate updateModel, ensure everything is Ok, not tampered/invalid.
        using (var ctx = new DBContext) 
        {
            var person = ctx.Persons
                // can .Include() any related entities that can be updated here...
                .Where( x => x.PersonId == updatePersonModel.PersonId )
                .Single();
            person.Name = updatePersonModel.Name;
            // etc.
            ctx.SaveChanges();
        }
    }
    
