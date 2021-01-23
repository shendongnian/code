    public class CustomEventListener : IPreInsertEventListener
    {
        public bool OnPreInsert(PreInsertEvent @event)
        {
            var entity = @event.Entity as Entity;
    
            if (entity.UserId == 0)
            {
                entity.UserId = entity.ServerId;
                Set(@event.Persister, @event.State, "UserId", entity.UserId);
            }
    
            return false;
        }
        private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }
    }
