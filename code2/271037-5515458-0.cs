    public class User
    {
        private IList<Event> _events;
        public IList<Event> Events
        {
            IsSuperAdmin ? Event.All : _events;
        }
    }
