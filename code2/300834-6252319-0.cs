            public static Repository<T> CreateRepository(T item)
            {
                if (addedItemList.Contains<Type>(item.GetType()))
                {
                    return new Repository<T> { Item = item };
                }
    
                addedItemList.Add(item.GetType());
                
                return CreateRepository(item);
                
            }
