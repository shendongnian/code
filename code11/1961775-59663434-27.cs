    public class Block
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double MinutesAbsent(IEnumerable<Presence> presences)
        {
            // Given a list of presences, select only those that overlap this block 
            var relevantPresences = Presence.CombineOverlapping(
                presences?.Where(p => p?.OverlapsWith(this) == true))?
                .OrderBy(p => p.Arrival)
                .ToList();
            // If there aren't any relevant presences, return the total minutes for this block
            if (relevantPresences == null || relevantPresences.Count == 0)
                return (End - Start).TotalMinutes;
            // Get any absent minutes at the start of the block by determining
            // if the first presence arrived after the block's start. If it did,
            // begin with the difference between the block's Start and the 
            // first presence's Arrival. 
            var minutesAbsent = relevantPresences.First().Arrival > Start
                ? (relevantPresences.First().Arrival - Start).TotalMinutes
                : 0;
            // Then add the number of minutes between each presence's 
            // Departure and the next presence's Arrival
            for (var i = 0; i < relevantPresences.Count - 1; i++)
            {
                minutesAbsent += (relevantPresences[i + 1].Arrival -
                                  relevantPresences[i].Departure).TotalMinutes;
            }
            // Finally, add any minutes after the last presence 
            // if it departed before the end of the block
            if (relevantPresences.Last().Departure < End)
                minutesAbsent += (End - relevantPresences.Last().Departure).TotalMinutes;
            return minutesAbsent;
        }
    }
    public class Presence
    {
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public TimeSpan FlightTime => Arrival - Departure;
        public Presence(){ }
        public Presence(DateTime arrival, DateTime departure)
        {
            Arrival = arrival;
            Departure = departure;
        }
        public bool OverlapsWith(Block block)
        {
            return Arrival < block?.End && Departure > block.Start;
        }
        public static IEnumerable<Presence> CombineOverlapping(IEnumerable<Presence> presences)
        {
            var items = presences?.ToList()
                .Where(p => p != null)
                .OrderBy(presence => presence.Arrival)
                .ToList();
            if (items == null || !items.Any()) return items;
            var combined = new List<Presence>();
            var current = items.First();
            for (var i = 1; i < items.Count; i++)
            {
                if (items[i].Arrival <= current.Departure)
                {
                    if (items[i].Departure > current.Departure)
                    {
                        current.Departure = items[i].Departure;
                    }
                }
                else
                {
                    combined.Add(current);
                    current = items[i];
                }
            }
            combined.Add(current);
            return combined;
        }
        public override string ToString()
        {
            return $"{Arrival} - {Departure}";
        }
    }
