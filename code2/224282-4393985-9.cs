    public string ToAssociationQueryString(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());
        AssociationQueryStringAttribute[] attributes = 
            (AssociationQueryStringAttribute[])fi.GetCustomAttributes(
                typeof(AssociationQueryStringAttribute), false);
        if (attributes.Length > 0)
        {
            return attributes[0].Value;
        }
        else
        {
            throw new InvalidOperationException(
                "Must use an enum decorated with the AssociationQueryString attribute.");
        }
    }
