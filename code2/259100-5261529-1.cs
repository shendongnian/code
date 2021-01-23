static IEnumerable&lt;InfoAndValue&gt; GetWritableProperties(Attribute attribute)
{
    var collection = from p in attribute.GetType().GetProperties()
                     where !p.PropertyType.Name.StartsWidth("Nullable`1")
                     select new InfoAndValue { 
                                    Info = p, 
                                    Value = p.GetValue(attribute, null) 
                                };
    return collection;
}
</pre>
