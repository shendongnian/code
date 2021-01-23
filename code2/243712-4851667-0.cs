    public class Subdomain
    {
        public int SubdomainID { get; set; }
    
        [CustomValidation(typeof(Subdomain), "ValidateActivities")]
        public virtual ICollection<SubdomainActivity> Activities { get; set; }
        public static ValidationResult ValidateActivities(ICollection<SubdomainActivity> activities)
        {
            if (activities.Count > 0)
            {
                int activitySum = activities.Sum(x => x.Value);
                if (activitySum != 100)
                {
                    return new ValidationResult(string.Format("The Activity percentages must add up to 100. Current sum is {0}", activitySum), new[] { "Activities" });
                }
            }
            return ValidationResult.Success;
        }
    }
