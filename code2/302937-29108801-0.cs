    public class Training : IValidatableObject
    {
        private const string Time = @"^(?:[01][0-9]|2[0-3]):[0-5][0-9]:00$";
        public int Id { get; set; }
        [Display(Name = "Starttime")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan StartTime { get; set; }
        [Display(Name = "Endtime")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan EndTime { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Regex timeRegex = new Regex(Time);
            if (!timeRegex.IsMatch(StartTime.ToString()))
            {
                results.Add(new ValidationResult("Starttime is not a valid time hh:mm", new[] { "StartTime" }));
            }
            if (!timeRegex.IsMatch(EndTime.ToString()))
            {
                results.Add(new ValidationResult("Endtime is not a valid time hh:mm", new[] { "EndTime" }));
            }
            return results;
        }
    }
