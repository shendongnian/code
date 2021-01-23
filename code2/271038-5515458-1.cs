    public class User
    {
        private IList<Event> _events;
        public IList<Event> Events
        {
            get { return IsSuperAdmin ? Event.All : _events; }
        }
    }
