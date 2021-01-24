    //
    // Summary:
    //     Configures the relationship to the owner.
    //     Note that calling this method with no parameters will explicitly configure this
    //     side of the relationship to use no navigation property, even if such a property
    //     exists on the entity type. If the navigation property is to be used, then it
    //     must be specified.
    //
    // Parameters:
    //   ownerReference:
    //     The name of the reference navigation property pointing to the owner. If null
    //     or not specified, there is no navigation property pointing to the owner.
    //
    // Returns:
    //     An object that can be used to configure the relationship.
    public virtual OwnershipBuilder<TEntity, TDependentEntity> WithOwner([CanBeNullAttribute] string ownerReference = null);
