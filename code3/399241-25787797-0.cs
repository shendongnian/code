            // Create an AssociateEntities request.
            //Namespace is Microsoft.Crm.Sdk.Messages
            DisassociateEntitiesRequest request = new DisassociateEntitiesRequest();
            // Set the ID of Moniker1 to the ID of the lead.
            request.Moniker1 = new EntityReference
            {
                Id = moniker1.Id,
                LogicalName = moniker1.Name
            };
            // Set the ID of Moniker2 to the ID of the contact.
            request.Moniker2 = new EntityReference
            {
                Id = moniker2.Id,
                LogicalName = moniker2.Name
            };
            // Set the relationship name to associate on.
            request.RelationshipName = strEntityRelationshipName;
            // Execute the request.
            service.Execute(request);
