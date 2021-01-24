    public override async Task<PersonaCompletoCollection>  ListaPersonas(PersonaCompleto request, IServerStreamWriter<PersonaCompletoCollection> responseStream, ServerCallContext context)
    {
        var itemsDb = await _context.Persona.ToListAsync();
        var itemsTransformed = itemsDb
            .Select(itemDb => new PersonaCompleto
            {
                Idpersona = item.idpersona,
                Apellido = item.apellido,
                Nombre = item.nombre,
                Edad = item.edad
            })
            .ToList();
        PersonaCompletoCollection res = new PersonaCompletoCollection
        {
            Title = true,
            Titlename = "doctor"
        };
        res.PersonasCompleto.AddRange(itemsTransformed);
        await responseStream.WriteAsync(res);
        return await Task.FromResult(res);
    }
