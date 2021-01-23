    public static void FillPropertiesOfCustomerOrPerson(dynamic person, Request request)
    {
      person.Name=request.Name;
      person.Surname=request.Surname;
    }
