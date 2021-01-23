    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        int activitySum = Activities.Sum(x => x.Value);
        if (Activities.Count != 0 && activitySum != 100)
        {
            yield return new ValidationResult(string.Format("The Activity percentages must add up to 100. Current sum is {0}", activitySum), new[] { "Activities" });
        }
    }  
