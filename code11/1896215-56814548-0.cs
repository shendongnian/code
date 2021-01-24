    public void AssociateEntities(IOrganizationService service, List<Entity> secondaryEntities, Entity primaryEntity, string relationshipName)
    {
        AssociateRequest request = new AssociateRequest
        {
            Relationship = new Relationship(relationshipName),
            Target = primaryEntity.ToEntityReference(),
            RelatedEntities = new EntityReferenceCollection(secondaryEntities.Select(x => x.ToEntityReference()))
        };
        OrganizationResponse response = service.Execute(request);
    }
