        using (var specialContext = new _navPropInhibitingContext())
        {
            var dbModel = new MyEntity() 
            {
                ...
            };
        
            specialContext.MyEntity.Add(dbModel);
            await specialContext.SaveChangesAsync();
        }
