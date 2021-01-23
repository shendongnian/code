    public partial class YourObjectContext
    {
        public override int SaveChanges(SaveOptions options)
        {
            foreach (ObjectStateEntry relationEntry in ObjectStateManager
                                                 .GetObjectStateEntries(EntityState.Deleted)
                                                 .Where(e => e.IsRelationship))
            {
                var entry = GetEntityEntryFromRelation(relationEntry, 0);
                // Find representation of the relation 
                IRelatedEnd relatedEnd = entry.RelationshipManager
                                              .GetAllRelatedEnds()
                                              .First(r => r.RelationshipSet == relationEntry.EntitySet);
                RelationshipType relationshipType = relatedEnd.RelationshipSet.ElementType;
                if (!SkipDeletion(relationshipType))
                {
                    // Now we know that model is inconsistent and entity on many side must be deleted
                    if (!(relatedEnd is EntityReference)) // related end is many side
                    {
                        entry = GetEntityEntryFromRelation(relationEntry, 1);
                    }
                    if (entry.State != EntityState.Deleted)
                    {
                        context.DeleteObject(entry.Entity);
                    }
                }
            }
            return base.SaveChanges();
        }
        private ObjectStateEntry GetEntityEntryFromRelation(ObjectStateEntry relationEntry, int index)
        {
            var firstKey = (EntityKey) relationEntry.OriginalValues[index];
            ObjectStateEntry entry = ObjectStateManager.GetObjectStateEntry(firstKey);
            return entry;
        }
        private bool SkipDeletion(RelationshipType relationshipType)
        {
            return
                // Many-to-many
                relationshipType.RelationshipEndMembers.All(
                    r => r.RelationshipMultiplicity == RelationshipMultiplicity.Many) ||
                // ZeroOrOne-to-many 
                relationshipType.RelationshipEndMembers.Any(
                    r => r.RelationshipMultiplicity == RelationshipMultiplicity.ZeroOrOne);
        }
    }
