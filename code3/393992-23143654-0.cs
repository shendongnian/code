    foreach(var map in Mapper.GetAllTypeMaps())
    {
        if (typeof(MyBaseClass).IsAssignableFrom(map.DestinationType))
        {
            var propInfo = map.DestinationType.GetProperty("PropertyToIgnore");
            if (propInfo != null)
                map.FindOrCreatePropertyMapFor(new AutoMapper.Impl.PropertyAccessor(propInfo)).Ignore();
            }
        }
    }
