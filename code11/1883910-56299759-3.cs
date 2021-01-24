    using System.Data.Entity;
    ...
    var image = context.Set<Image>().Include(i => i.Content)
                       .Single(i => i.Id == id);
    context.Entry(image).State = EntityState.Deleted;
    context.Entry(image.Content).State = EntityState.Deleted;
