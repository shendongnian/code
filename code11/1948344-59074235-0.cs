    public class Participant
    {
        public IEnumerable<Participant> Participants {get; set;}
        public int ParticipantNumber { get; set; }
        public string ParticipantName { get; set; }
        public string ParticipantLocation { get; set; }
        public long ParticipantPhoneNumber { get; set; }
        public int ParticipantTimeSlot { get; set; }
        public void GetParticipants()
        {
            IEnumerable<string> lines = null;
            using (OpenFileDialog ofd = new OpenFileDialog())            
                if (ofd.ShowDialog() == DialogResult.OK)
                    // remove empty lines and lines that start with *
                    lines = File.ReadLines(ofd.FileName).Where(line => !string.IsNullOrEmpty(line) && !line.StartsWith("***"));
            // if we don't have anything return
            if (lines == null)
                return;
            // get all our participants we can based on just 5 fields
            Participants = lines.Select((value, index) => new { value, index})
                .GroupBy(grp => grp.index / 5, myVal => myVal.value)
                .Select(val => new Participant() 
                                { 
                                    ParticipantNumber = int.TryParse(val.Select(s => s).Where(s=> s.StartsWith("Participant:"))
                                    .FirstOrDefault().Replace("Participant:", string.Empty).Trim(), out int parNumber) ? parNumber : 0,
                                    ParticipantLocation = val.Select(s => s).Where(s => s.StartsWith("Location:"))
                                    .FirstOrDefault().Replace("Location:", string.Empty).Trim(),
                                    ParticipantName = val.Select(s => s).Where(s => s.StartsWith("Name:"))
                                    .FirstOrDefault().Replace("Name:", string.Empty).Trim(),
                                    ParticipantPhoneNumber = long.TryParse(val.Select(s => s).Where(s => s.StartsWith("Phone Number:"))
                                    .FirstOrDefault().Replace("Phone Number:", string.Empty).Trim(), out long parPhone) ? parPhone : 0,
                                    ParticipantTimeSlot = int.TryParse(val.Select(s => s).Where(s => s.StartsWith("Time Slot:"))
                                    .FirstOrDefault().Replace("Time Slot:", string.Empty).Trim(), out int parTime) ? parTime : 0
                }) ;            
        }              
    }
    public static class LinqExtentions
    {
        public static IEnumerable<IEnumerable<T>> GroupWhile<T>(this IEnumerable<T> seq, Func<T, T, bool> condition)
        {
            T prev = seq.First();
            List<T> list = new List<T>() { prev };
            foreach (T item in seq.Skip(1))
            {
                if (condition(prev, item) == false)
                {
                    yield return list;
                    list = new List<T>();
                }
                list.Add(item);
                prev = item;
            }
            yield return list;
        }               
    }
    
