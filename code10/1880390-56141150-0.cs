     var grouped = users.GroupBy(u => u.Name < "M").OrderBy(g => g.Key).ToArray();
     return new CategorizedByLetterUserDto
     {
        AtoL = grouped[1].Select(x => new UserDto { Id = x.Id, Name = x.Name }),
        MtoZ = grouped[0].Select(x => new UserDto { Id = x.Id, Name = x.Name }),
     };
