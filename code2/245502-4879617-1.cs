        /// <summary>
        /// blah blah code.
        /// </summary>
        [DataMember]
        [StringLengthValidator(8, RangeBoundaryType.Inclusive, 8, RangeBoundaryType.Inclusive, MessageTemplate = "\"{1}\" must always have \"{4}\" characters.")]
        public string Code { get; set; }
