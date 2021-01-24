    /// <summary>
    /// Specifies an entity-name.
    /// </summary>
    /// <remarks>See http://nhforge.org/blogs/nhibernate/archive/2008/10/21/entity-name-in-action-a-strongly-typed-entity.aspx</remarks>
    public void EntityName(string entityName)
    {
        attributes.Set("EntityName", Layer.UserSupplied, entityName);
    }
