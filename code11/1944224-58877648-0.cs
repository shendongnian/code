  private void BuildContext() { 
    Context context = Provider.GetService<Context>();
    if(!context.Countries.Any())
    {
        context.Countries.Add(new Country { Code = "fr", Name = "France" });
        context.SaveChanges();
    }
  }
