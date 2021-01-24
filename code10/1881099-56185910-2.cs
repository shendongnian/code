    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;
    
    namespace EmergenceGuardian.WebsiteTools.Web
    {
        /// <summary>
        /// Represents a list of items to display as radio buttons or drop down list that can be bound to a web page and validated.
        /// </summary>
        [InputListValidation]
        public class InputList
        {
            /// <summary>
            /// Initializes a new instance of InputList with specified list of items that will be used for both the value and text.
            /// </summary>
            /// <param name="values">A list of string values reprenting valid values.</param>
            /// <param name="required">Whether this field is required.</param>
            public InputList(IEnumerable<string> values, bool required = true)
            {
                Required = required;
                foreach (var item in values)
                {
                    ListItems.Add(new SelectListItem(item, item));
                }
            }
    
            /// <summary>
            /// Initializes a new instance of InputList with specified list of SelectListItem objects.
            /// </summary>
            /// <param name="values">A list of SelectListItem objects representing display text and valid values.</param>
            /// <param name="required">Whether this field is required.</param>
            public InputList(IEnumerable<SelectListItem> values, bool required = true)
            {
                Required = required;
                ListItems.AddRange(values);
            }
    
            /// <summary>
            /// Initializes a new instance of InputList with a NameValueCollection allowing quick collection initializer.
            /// </summary>
            /// <param name="values">The NameValueCollection containing display texts and valid values.</param>
            /// <param name="required">Whether this field is required.</param>
            public InputList(NameValueCollection values, bool required = true)
            {
                Required = required;
                foreach (var key in values.AllKeys)
                {
                    ListItems.Add(new SelectListItem(values[key], key));
                }
            }
    
            /// <summary>
            /// Gets or sets whether this field is required.
            /// </summary>
            public bool Required { get; set; }
            /// <summary>
            /// Gets or sets the list of display text and valid values, used for display and validation.
            /// </summary>
            public List<SelectListItem> ListItems { get; set; } = new List<SelectListItem>();
            /// <summary>
            /// Gets or sets the user input value. This value can be bound to the UI and validated by InputListValidation.
            /// </summary>
            public string Value { get; set; }
        }
    
        /// <summary>
        /// Validates an InputList class to ensure Value is contained in ListItems.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        sealed public class InputListValidationAttribute : ValidationAttribute
        {
            private const string DefaultErrorMessage = "Selected value is invalid.";
            private const string DefaultRequiredErrorMessage = "The {0} field is required.";
    
            public InputListValidationAttribute()
            {
            }
    
            /// <summary>
            /// Validates whether InputList.Value contains a valid value.
            /// </summary>
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var input = value as InputList;
                if (input != null)
                {
                    if (string.IsNullOrEmpty(input.Value))
                    {
                        if (input.Required)
                        {
                            return new ValidationResult(string.Format(ErrorMessage ?? DefaultRequiredErrorMessage, validationContext.MemberName));
                        }
                    }
                    else if (input.ListItems?.Any(x => x.Value == input.Value) == false)
                    {
                        return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
                    }
    
                }
                return ValidationResult.Success;
            }
        }
    }
