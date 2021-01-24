    public IEnumerable<User> ReadUsers(string path)
    {
      return File.ReadLines(path)
        .Select(l=>l.Split(";"))
        .Select(l=> new User
        {
          Id = int.Parse(l[0]),
          Name = l[1],
          IsAdmin = bool.parse(l[2])
        });
    }
