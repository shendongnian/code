    public class Person
    {
        public bool IsActive { get; set; }
        public List<Activity> Activities { get; set; }
        public string Name { get; set;}
    }
    
    public class Activity
    {
        public string ActivityType { get; set; }
        public uint Hours { get; set; }
    }
    
    public class Example
    {
        private const uint Threshold = 60;
        public void CheckHours(IEnumerable<Person> persons)
        {
            foreach (var person in persons)
            {
                var grouped = (from a in person.Activities
                    group a by a.ActivityType
                    into groupedActivities
                        select new { Activity = groupedActivities.Key, TotalHours = groupedActivities.Sum(g => g.Hours)}).ToList();
    
                foreach (var group in grouped)
                {
                    if(group.TotalHours > Threshold)
                        throw new Exception($"Activity {group.Activity} for person {person.Name} has exceeded the threshold!");
                }
    
            }
        }
    }
