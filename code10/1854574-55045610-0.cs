        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(SelectedRequestType == RequestType.PaidLeaveOfAbsence) 
            {
                // Check if field is not null and return
                yield return new ValidationResult(
                "SomeField should be present.",
                new[] { "SomeField" });
            }
        }
