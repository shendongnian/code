        public static void Register(IEventHandler<IDomainEvent> callback)
        {
            if (Actions == null)
            {
                Actions = new List<IEventHandler<IDomainEvent>>();
            }
            Actions.Add(callback);
        }
