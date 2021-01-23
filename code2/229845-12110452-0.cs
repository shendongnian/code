    public void OnPostRecreateCollection(PostCollectionRecreateEvent @event)
            {
                var session = @event.Session.GetSession(EntityMode.Poco);
                var propertyBeingUpdated = @event.Session.PersistenceContext.GetCollectionEntry(@event.Collection).CurrentPersister.CollectionMetadata.Role;
    
                var newCollectionString = @event.Collection.ToString();
                var oldCollection = (@event.Collection.StoredSnapshot as IList<object>).Select(o => o.ToString()).ToList();
                var oldCollectionString = string.Join(", ",oldCollection.ToArray());
    
                if (newCollectionString == oldCollectionString || (string.IsNullOrEmpty(newCollectionString) && string.IsNullOrEmpty(oldCollectionString)))
                    return;
                
                User currentUser = GetLoggedInUser(session);
                session.Save(new Audit
                {
                    EntityName = @event.AffectedOwnerOrNull.GetType().Name,
                    EntityId = (int)@event.AffectedOwnerIdOrNull,
                    PropertyName = propertyBeingUpdated,
                    AuditType = "Collection Modified",
                    EventDate = DateTime.Now,
                    NewValue = newCollectionString,
                    OldValue = oldCollectionString,
                    AuditedBy = Environment.UserName,
                    User = currentUser
                });
            }
