public IOrderedQueryable<Detail> GetProductList(string GroupName, string TypeName, Dictionary<string,List<string>> filterDictionary)
{
    var q = from c in db.Detail
            where c.GroupName == GroupName && c.TypeName == TypeName
            // insert dynamic filter here
            orderby c.TypeName
            select c;
    return q;
}
