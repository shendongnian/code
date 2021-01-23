    foreach (EntityType entity in ItemCollection.GetItems<EntityType>().OrderBy(e => e.Name))
    foreach (var entityMember in entity.NavigationProperties)
    foreach (System.Data.Metadata.Edm.EdmProperty foreignKey in entityMember.GetDependentProperties())
    {
    	//... use foreignKey
    }
