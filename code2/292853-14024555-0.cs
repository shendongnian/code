    using EntityFramework.Extensions;
   ....
    using (var entities = new Entity())
    {                               
        entities.Items.Delete(x => x.id == id);
        entities.SaveChanges();
    }
    ...
