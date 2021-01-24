            public void TryUpdateModel<T>(T existingModel, T newModel)
        {
            PropertyInfo[] properties = existingModel.GetType()
                                                    .GetProperties()
                                                    .Where(pi => !(pi.PropertyType.IsSubclassOf(typeof(T))))
                                                    .ToArray();
            foreach (var item in properties)
            {
                var propName = item.Name;
                if (item.PropertyType.IsSealed && item.PropertyType.IsSerializable && item.Name != existingModel.GetType().Name + "Id")
                {
                    var newValue = db.Entry(newModel).Property(propName).CurrentValue;
                    db.Entry(existingModel).Property(propName).CurrentValue = newValue;
                }
            }
        }
