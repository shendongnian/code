    public class MySaveOrUpdateEventListener : ISaveOrUpdateEventListener
    {
        public void OnSaveOrUpdate(SaveOrUPdate @event)
        {
            if (@event.entity is Person)
            {
                var person = (Person)@event.entity;
                if (person.Address is NullAddress)
                    person.Address = null;
            }
        }
    }
