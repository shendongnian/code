var originalEntity = Context.Property.Include("PropertyInfo")
                        .AsNoTracking()
                        .FirstOrDefault(e => e.Id == 1);
originalEntity.Id = 0;
//either create propertyinfo or assign propertyinfo
originalEntity.PropertyInfo = createdPropertyInfo || Context.PropertyInfo.First(x => x.Id == idOfFKPropertyInfo);
 Context.Properties.Add(originalEntity);
