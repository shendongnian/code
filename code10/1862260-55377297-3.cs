      MyUsers = File.ReadAllLines(path)
        .Where(linia => linia.Length > 1)
        .Select(line => Parse(line))
        .GroupBy(
          u => u.idUser, 
          (key, grp) => new User() {
            ReadTime = grp.Select(u => u.ReadTime).Max(),
            idUser = key,
            LastName = grp.Select(u => u.LastName).FirstOrDefault(),
            FirstName = grp.Select(u => u.FirstName).FirstOrDefault(),
            City = grp.Select(u => u.City).FirstOrDefault(),
          })
        .ToList();
