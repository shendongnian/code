     public class Reminder
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ReminderId { get; set; }
        public bool Status { get; set; }
        public string ReminderLocation { get; set; }
        //in terms of days
        public DateTime ReminderCreationDate { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Tasks> ThingsTodo { get; set; }
        [TextBlob(nameof(Taskblodded))]
        public string Taskblodded { get; set; }
    }
