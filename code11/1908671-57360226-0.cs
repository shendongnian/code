    using (var context = new YourContext())
    {
        var action= new Action();
        MapToEntity(input, action);// I asume your details are also included in the input
        context.Actions.Add(action);
        context.SaveChanges();
    }
