    var img1 = context.Set<Image>(). Single(i => i.Id == 1);
    img1.Content = new ImageContent { ImageId = img1.Id }; // Stub entity
    context.Entry(img1.Content).State = Entity.EntityState.Unchanged; // Attach to context
    context.Set<Image>().Remove(img1);
    context.SaveChanges();
