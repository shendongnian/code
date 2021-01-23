    public static class DynamicToStatic
    {
        public static T ToStatic<T>(object expando)
        {
            var entity = Activator.CreateInstance<T>();
    
            var properties = expando as IDictionary<string, object>; //ExpandoObject implements dictionary
    
            if (properties == null)
                return entity;
    
            foreach (var entry in properties)
            {
                entity.GetType().GetProperty(entry.Key).SetValue(entity, entry.Value, null);
            }
            return entity;
        }
    }
    dynamic CurUser = _users.GetSingleUser(UserID);   
    var retUser = DynamicToStatic.ToStatic<UserModel>(CurUser);
