    foreach (var key in dbContext.Model.FindEntityType(typeof(Entity)).GetKeys())
    {
        foreach (var property in key.Properties)
        {
            if (property.ValueGenerated == Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd)
            {
                Console.WriteLine("gotcha!");
            }
        }
    }
