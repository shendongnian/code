        public class SettingMetadata
        {
            [Display(Name="Base Rate")]
            [Required]
            public decimal Rate
            {
                get;
                set;
            }
    
            [Display(Name = "Permit Payments")]
            public Boolean AllowPayments
            {
                get;
                set;
            }
    
            [Display(Name = "Base URL For Web Service")]
            [Required]
            [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Type must match linked metadata type.")]
            public string WebServiceUrl
            {
                get;
                set;
            }
        }
