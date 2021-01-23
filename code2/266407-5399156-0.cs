    class SimpleClassDAL
    {
        [...]
        public void Refresh(ISession session, SimpleClass simple)
        {
            var persistentcollection = simple.Childs as IPersistentCollection;
            if (persistentcollection.WasInitialized)
            {
                // get everything again
                session.Refresh(simple);
            }
            else
            {
                // only refresh simple
                session.Evict(simple);
                simple = session.Get<SimpleClass>(simple.Id);
    
            }
        }
    }
