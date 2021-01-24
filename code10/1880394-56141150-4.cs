     var grouped = users.GroupBy(u => u.Name.CompareTo("M") < 0).OrderBy(g => g.Key).ToArray();
     return new CategorizedByLetterUserDto
     {
        AtoL = grouped[1].Select(x => new UserDto { Id = x.Id, Name = x.Name }),
        MtoZ = grouped[0].Select(x => new UserDto { Id = x.Id, Name = x.Name }),
     };
