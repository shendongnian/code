    public static string FullName(this Dictionary<Id, Category> map, Id id)
    {
        return map.CategoryAndParents(id)
                  .Aggregate("", (string name, Category cat) =>
                    cat.Name + (name == "" ? "" : @"/") + name);
    }
