        public static string GetUniqueId<T, TProperty>(this IQueryable<T> source, int length, Func<T, TProperty> idProperty)
    {         
    bool isUnique = false;         
    string uniqueId = String.Empty;         
    while (!isUnique) 
    {             
    uniqueId = PasswordGenerator.GenerateNoSpecialCharacters(length);             
    if (!String.IsNullOrEmpty(uniqueId)) 
    { 
    isUnique = source.SingleOrDefault(i => idProperty(i).Equals(uniqueId)) == null;
    }
    }
    return uniqueId;
    } 
