    // C#
    IRelationPredicateBucket bucket = new RelationPredicateBucket();
    bucket.Relations.Add(CustomerEntity.Relations.AddressEntityUsingVisitingAddressID, "VisitingAddress");
    bucket.Relations.Add(CustomerEntity.Relations.AddressEntityUsingBillingAddressID, "BillingAddress");
    bucket.PredicateExpression.Add((AddressFields.City.SetObjectAlias("VisitingAddress")=="Amsterdam") &
    	 (AddressFields.City.SetObjectAlias("BillingAddress")=="Rotterdam"));
    EntityCollection customers = new EntityCollection(new CustomerEntityFactory());
    DataAccessAdapter adapter = new DataAccessAdapter();
    adapter.FetchEntityCollection(customers, bucket);
