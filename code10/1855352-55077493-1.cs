    public JsonResult OnGetList()
    {
        var list = new List<PersonDto>();
    
        foreach (var item in _context.Person.ToList())
        {
            list.Add(new PersonDto(item.PersonName, item.PersonAddress));
        }
    
        return new JsonResult(list);
    }
