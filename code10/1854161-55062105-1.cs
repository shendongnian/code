    namespace Websites.Business.Validation {
        /// <summary>
        /// Provides methods to validate objects based on DataAnnotations.
        /// </summary>
        public static class ValidationExtensions {
            /// <summary>
            /// Validates an object based on its DataAnnotations and throws an exception if the object is not valid.
            /// </summary>
            /// <param name="obj">The object to validate.</param>
            public static T ValidateAndThrow<T>(this T obj) {
                Validator.ValidateObject(obj, new ValidationContext(obj), true);
                return obj;
            }
            /// <summary>
            /// Validates an object based on its DataAnnotations and returns a list of validation errors.
            /// </summary>
            /// <param name="obj">The object to validate.</param>
            /// <returns>A list of validation errors.</returns>
            public static ICollection<ValidationResult> Validate<T>(this T obj) {
                var Results = new List<ValidationResult>();
                var Context = new ValidationContext(obj);
                if (!Validator.TryValidateObject(obj, Context, Results, true))
                    return Results;
                return null;
            }
        }
    }
