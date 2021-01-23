    public class PatientMetadata
    {
        [RangeValidator(0, RangeBoundaryType.Inclusive, 10, RangeBoundaryType.Ignore)]
        public int DiagnosisCount { get; set; }
        [StringLengthValidator(6, ErrorMessage = "Name must not exceed 6 chars.")]
        public string Name { get; set; }
    }  
