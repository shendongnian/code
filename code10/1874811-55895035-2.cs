    public class Customer
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public List<Achievement> Achievements { get; set; }
        public bool AddAchievement(Achievement newAchievement)
        {
            // Check to ensure customer doesn't already have the new achievement
            // Persist to the database
            // Add to local collection
            Achievements.Add(newAchievement);
            // Send email to customer
            // Anything else
            // Return
            return true;
        }
    }
