        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validations = new List<ValidationResult>();
            if (From.HasValue && Until.HasValue)
            {
                if (From.Value.Date < Until.Value.Date)
                    validations.Add(new ValidationResult("StartDateMustBeBeforeEndDate"));
                else if (From.Value.Date == From.Value.Date 
                            && From.Value.Hour < Until.Value.Hour)
                    validations.Add(new ValidationResult("StartHourMustBeBeforeEndHour"));
                else if (From.Value.Date == From.Value.Date 
                            && From.Value.Hour == Until.Value.Hour 
                            && From.Value.Minute < Until.Value.Minute)
                    validations.Add(new ValidationResult("StartMinuteMustBeBeforeEndMinute"));
            }
            return validations;
        }
