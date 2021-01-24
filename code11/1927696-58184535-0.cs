    //First Method :
        
    Entity await _repository = new Entity() // object of your entity.
    var Result = (from a in await _repository.Person.Where(a=>a.PersonId == id)
                  from b in await _repository.Location.Where(b=>b.PersonId=a.PersonId)
                  select new 
                  {
                     a.PersonId,a.PersonName,b.Country
                  }).SingleOrDefault();
    Result.Country; // Here you can get country,also get other values PersonName,PersonId
    //Second Method :
    
    Entity await _repository = new Entity() // object of your entity.
    var Result = (from a in await _repository.Location.Where(a=>a.PersonId == id)select 
                  a.Country).SingleOrDefault(); //other wise you can select 'a'.  
    Result.Country; // Here you can get country
                  
