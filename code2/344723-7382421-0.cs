    IOrganizationService service = GetOrganizationService();
    var entity = service.Retrieve(entityName,
                                    entityId,
                                    new ColumnSet(new[]
                                                    {
                                                        stringAttributeName,
                                                        intAttributeName,
                                                        floatAttributeName,
                                                        boolAttributeName,
                                                        optionSetAttributeName,
                                                        entityReferenceAttributeName,
                                                    }));
    var stringValue = entity.GetAttributeValue<string>(stringAttributeName);
    var intValue = entity.GetAttributeValue<int?>(intAttributeName);
    var floatValue = entity.GetAttributeValue<double?>(floatAttributeName);
    var boolValue = entity.GetAttributeValue<bool?>(boolAttributeName);
    var optionSetValue = entity.GetAttributeValue<OptionSetValue>(optionSetAttributeName);
    var entityReferenceValue = entity.GetAttributeValue<EntityReference>(entityReferenceAttributeName);
