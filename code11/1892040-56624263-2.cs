    public int CountActiveSocios()
    {
        var dbContextOptions = DbContextHelper.GetDbContextOptions();
        using (var context = new yangsoftDBContext(dbContextOptions)) // <-- Pass the options here
        {
           try
           {
               return context.Socios.Where(r => r.Estado == true).Count();
           }
           catch
           {
              return 0;
           }
        }
    }
