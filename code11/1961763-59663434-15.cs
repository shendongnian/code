    public class Block
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; } 
        public double MinutesAbsent(IEnumerable<Presence> presences)
        {
            // Given a list of presences, select only those that overlap this block 
            var relevantPresences = presences?
                .Where(p => p.Arrival < End && p.Departure > Start)
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
                ? (Start - relevantPresences.First().Arrival).TotalMinutes
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
