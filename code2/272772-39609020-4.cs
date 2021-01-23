    context.InsertOrUpdateGraph(person)
           .After(entity =>
           {
                // Delete missing phones.
                entity.HasCollection(p => p.Phones)
                   .DeleteMissingEntities();
    
                // Delete if spouse is not exist anymore.
                entity.HasNavigationalProperty(m => m.PersonSpouse)
                      .DeleteIfNull();
           });
