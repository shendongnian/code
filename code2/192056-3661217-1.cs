    if(!user.CanSeeRestrictedFields)
       var results = from p as Repository.AsQueryable<Person>()
       //rest of Linq statement
       select new Person { 
             Name = p.Name,
             Age = p.Age
          };
    else
       var results = from p as Repository.AsQueryable<Person>()
       //rest of Linq statement
       select new Person { 
             Name = p.Name,
             Age = p.Age,
             SocialSecurityNumber = p.SocialSecurityNumber,
             MothersMaidenName = p.MothersMaidenName
          };
