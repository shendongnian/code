    public static class EntityHelper
    {
        public static string ValidateProperty(object obj, string propertyName)
        {
            // get the MetadataType attribute on the object class
            Type metadatatype = obj.GetType().GetCustomAttributes(true).OfType<MetadataTypeAttribute>().First().MetadataClassType;
            // get the corresponding property on the MetaDataType class
            PropertyInfo property = metadatatype.GetProperty(propertyName);
            // get the value of the property on the object
            object value = obj.GetType().GetProperty(propertyName).GetValue(obj, null);
            // run the value through the ValidationAttributes on the corresponding property
            List<string> errors = (from v in property.GetCustomAttributes(true).OfType<ValidationAttribute>() where !v.IsValid(value) select v.ErrorMessage).ToList();           
            // return all the errors, or return null if there are none
            return (errors.Count > 0) ? String.Join("\r\n", errors) : null;
        }
    }
    [MetadataType(typeof(Employee.MetaData))]
    public partial class Employee:IDataErrorInfo
    {
        private sealed class MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "A name must be defined for the employee.")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must  be between 3-50 characters long.")]
            public object Name { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "A username must be defined for the employee.")]
            [StringLength(20, MinimumLength = 3, ErrorMessage = "The username must be between 3-20 characters long.")]
            public object Username { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "A password must be defined for the employee.")]
            [StringLength(20, MinimumLength = 3, ErrorMessage = "The password must be between 3-20 characters long.")]
            public object Password { get; set; }
        }
        public string Error { get { return String.Empty; } }
        public string this[string property] { get { return EntityHelper.ValidateProperty(this, property); } }
    }
