    PersonDTO aliasDTO = null;
    q = q.SelectList(list => list
            .Select(p => p.Id).WithAlias(() => aliasDTO.Id)
            .Select(p => p.FirstName).WithAlias(() => aliasDTO.FirstName)
            .Select(p => p.LastName).WithAlias(() => aliasDTO.LastName)
            .Select(p => p.Identity.Sex).WithAlias(() => aliasDTO.Sex)
            .Select(p => p.Identity.BirthDate).WithAlias(() => aliasDTO.BirthDate))
        .TransformUsing(Transformers.AliasToBean<PersonDTO>())
        .List<PersonDTO>();
    // or
    q = q.Select(person => new PersonDto
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Sex = person.Identity.Sex,
            BirthDate = person.Identity.BirthDate,
        })
        .TransformUsing(Transformers.AliasToBean<PersonDTO>())
        .List<PersonDTO>();
