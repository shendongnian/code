    private User Authenticate(LoginViewModel model) 
    { 
        using (HutLogisticaContext context = new HutLogisticaContext()) 
        { 
            return context.Users
                          .Include(u => u.Roles)
                          .Where(u => u.Id == 123)
                          .SingleOrDefault(); 
        } 
    }
