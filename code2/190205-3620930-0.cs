using System.Data.Metadata.Edm;
...
public virtual List&lt;T> LoadProperty(List&lt;T> entities, string property) {
    using (TrialsContext context = new TrialsContext()) {
        
        EntityContainer container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);                                
        EntitySetBase entitySet = container.BaseEntitySets.Where(item => item.ElementType.Name.Equals(typeof(T).Name)).FirstOrDefault();
        foreach (T entity in entities) {
            context.AttachTo(entitySet.Name, entity);
            context.LoadProperty(entity, property);
        }
    return entities;
}
