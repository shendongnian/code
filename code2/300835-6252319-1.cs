            public static Repository<T> CreateRepository()
            {
                if (addedItemList.Contains<Type>(typeof(T)))
                {
                    return new Repository<T> { Item = default(T) };
                }
    
                addedItemList.Add(typeof(T));
    
                return CreateRepository();
            }
