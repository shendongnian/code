    public class Activity
    {
        [Required]
        public DateTime AddedDate { get; set; }
    
        public Activity()
        {
            AddedDate = DateTime.Now;
        }
    }
