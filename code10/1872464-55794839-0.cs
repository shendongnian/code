                var allEvents = new List<Event>()
                {
                    new Event(1, 1),
                    new Event(1, 2),
                    new Event(1, 3),
                    new Event(1, 4),
                    new Event(1, 5),
                    new Event(2, 1),
                    new Event(2, 2),
                    new Event(2, 3),
                    new Event(2, 4),
                    new Event(2, 5),
                    new Event(2, 6),
                    new Event(3, 1),
                    new Event(3, 2),
                    new Event(3, 3),
                };
                Dictionary<int, List<int>> dict = allEvents
                    .GroupBy(x => x.Id, y => y.Seq)
                    .ToDictionary(x => x.Key, y => y.ToList());
                Dictionary<int, List<int>> results = dict.Where(x => x.Value.Any(y => y >= 4))
                    .GroupBy(x => x.Key, y => y.Value)
                    .ToDictionary(x => x.Key, y => y.Where(z => z.Any(a => a >= 4)).SelectMany(a => a.Where(b => b >= 4)).ToList());
            }
