        [Required(ErrorMessageResourceType = typeof(CCSModelResources), ErrorMessageResourceName = "ANTCommonTextRequiredMessage")]
        [RegularExpression(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$",
            ErrorMessageResourceType = typeof(CCSModelResources), ErrorMessageResourceName = "ANTCommonTextRegularExpressionMessage")]
        public new string EmailAddress 
        {
            get { return base.EmailAddress; }
            set { base.EmailAddress = value; } 
        }
