    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                EventManager _eventManger = new EventManager();
                var results = _eventManger.events.SelectMany(x => x.EventUsers.Select(y => y))
                    .GroupBy(x => x.UserId)
                    .Select(x => new { UserId = x.First().UserId, count = x.Where(y => y.HasResponded == false).Count() })
                    .ToList();
            }
        }
        public class EventManager
        {
            public List<Event> events { get; set; }
        }
        public class EventUser
        {
            public int EventId { get; set; }
            public Event Event { get; set; }
            public long UserId { get; set; }
            public User User { get; set; }
            public bool HasResponded { get; set; }
        }
        public class Event
        {
            public List<EventUser> EventUsers { get; set; }
        }
        public class User
        {
            public List<EventUser> EventUsers { get; set; }
        }
    }
