    foreach(long id in ids)
    {
      var sampleEntity = context.SampleEntities.SingleOrDefault( e => e.Id == id);
      if(sampleEntity!=null)
         context.SampleEntities.DeleteObject(sampleEntity);
    }
    context.SaveChanges();
