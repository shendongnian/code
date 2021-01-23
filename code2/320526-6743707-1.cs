    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class Traffic
    {
        public DateTime Date { get; set; }
        public int PersonId { get; set; }
        public int TrafficId { get; set; }
    }
    class TrafficType
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>()
            {
                new Person()
                {
                    Id = 1001,
                    FirstName = "David",
                    LastName = "Jones",
                },
            };
            var trafficTypes = new List<TrafficType>()
            {
                new TrafficType()
                {
                    Id = 456,
                    Description = "sample description",
                },
            };
            var traffics = new List<Traffic>()
            {
                new Traffic()
                {
                    PersonId = 1001,
                    TrafficId = 456,
                    Date = DateTime.Now,
                },
            };
            var joinedData = from p in persons
                             from t in traffics
                             from tt in trafficTypes
                             where p.Id == t.PersonId
                                && tt.Id == t.TrafficId
                             select new
                             {
                                 PersonId = p.Id,
                                 FirstName = p.FirstName,
                                 LastName = p.LastName,
                                 // Remove time component, if present
                                 Date = t.Date.Date,
                                 Description = tt.Description,
                             };
            foreach (var item in joinedData)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}"
                    , item.PersonId
                    , item.FirstName
                    , item.LastName
                    , item.Date.ToShortDateString() // Don't print the time
                    , item.Description
                    );
            }
        }
    }
