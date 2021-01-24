    public static Func<ContactCustomFieldsFacet, string> MakeAccessor(string key)
    {
        var tFacet = typeof(ContactCustomFieldsFacet);
        var piFields = tFacet.GetProperty("Fields");
        var miFieldsGet = piFields.PropertyType.GetMethod("get_Item");
        var param = Expression.Parameter(tFacet, "facet");
        var lambda = Expression.Lambda<Func<ContactCustomFieldsFacet, object>>
        (
            Expression.Call
            (
                // Instance for invocation: param.Fields
                Expression.MakeMemberAccess(param, piFields),
                // Method to call
                miFieldsGet,
                // Call arguments
                Expresion.Constant(key)
            ),
            param
        );
        return lambda.Compile();
    }
