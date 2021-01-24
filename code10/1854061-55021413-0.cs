    company c;
        try
        {
           c.GetType().GetProperties().SetValue(c, entity.GetType().GetProperty(c.GetType().GetProperties().Name).GetValue(entity, null), null);
        }
        catch (Exception ex)
        {
        }
    
    
    .....
    //Update model
