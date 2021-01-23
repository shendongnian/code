    private static void TestDeleteDestination()
    {
        Destination canyon;
        using (var context = new BreakAwayContext())
        {
            canyon = (from d in context.Destinations
            where d.Name == "Grand Canyon"
            select d).Single();
        }
        DeleteDestination(canyon);
    }
    private static void DeleteDestination(Destination destination)
    {
        using (var context = new BreakAwayContext())
        {
            context.Destinations.Attach(destination);
            context.Destinations.Remove(destination);
            context.SaveChanges();
        }
    }
