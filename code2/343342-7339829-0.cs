    public override int SaveChanges()
    {
        var responses = Responses.Local.Where(r => r.Patient == null);
        foreach (var response in responses.ToList())
        {
            Responses.Remove(response);
        }
        return base.SaveChanges();
    }
