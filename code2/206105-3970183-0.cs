    IEnumrable<Person> listOfPersons = this.businessLayer.ReturnPersons();
    if (arg1 isNotNull)
        listOfPersons = listOfPersons.Where(p=> p.FirstName == arg1);
    if (arg2 usNotNull)
        listOfPersons = listOfPersons.Where(p=> p.LastName == arg2);
    ...
    var persons= from p in listOfAPerson
      select new
      {
        FirstName = p.FirstName,
        LastName = p.LastName,
        Age = p.Age,
        Address = p.Address,
        PhoneNumber = p.PhoneNumber
      };
