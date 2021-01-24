        public class Test
        {
            /// <summary>
            /// Order Number
            /// </summary>
            [Level("Level")]
            public int? OrderNumber { get; set; }
            /// <summary>
            /// Level 
            /// </summary>
            public string Level { get; set; }
        }
        public class LevelAttribute : ValidationAttribute
        {
            private string PropName { get; set; }
            public LevelAttribute(string prop)
            {
                this.PropName = prop;
            }
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                System.Reflection.PropertyInfo property = validationContext.ObjectInstance.GetType().GetProperty(this.PropName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
                
                object propertyvalue = property.GetValue(validationContext.ObjectInstance, new object[0]);
                if (value != null && propertyvalue != null && (propertyvalue.Equals("D1") || propertyvalue.Equals("D2")))
                {
                    return new ValidationResult("Invalid Error Message");
                }
                return ValidationResult.Success;
            }
        }
 
