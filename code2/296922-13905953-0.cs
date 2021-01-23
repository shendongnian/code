    public T Get<T>(int id) where T : EntityObject;
    {
    var ObjectSet = _context.CreateObjectSet<T>();
    var PropName = ObjectSet.EntitySet.ElementType.KeyMembers[0].ToString();
    return  ObjectSet.Where("it." + PropName + "=" + id).FirstOrDefault();
    }
