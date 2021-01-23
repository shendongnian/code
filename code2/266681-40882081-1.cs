    public class ExceptionHelper
    {
        public static Exception CreateFromEntityValidation(DbEntityValidationException ex)
        {
            return new Exception(GetDbEntityValidationMessage(ex), ex);
        }
    
        public static string GetDbEntityValidationMessage(DbEntityValidationException ex)
        {
            // Retrieve the error messages as a list of strings.
            var errorMessages = ex.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);
    
            // Join the list to a single string.
            var fullErrorMessage = string.Join("; ", errorMessages);
    
            // Combine the original exception message with the new one.
            var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
            return exceptionMessage;
        }
    
        public static IEnumerable<Exception> GetInners(Exception ex)
        {
            for (Exception e = ex; e != null; e = e.InnerException)
                yield return e;
        }
    
        public static Exception CreateFromDbUpdateException(DbUpdateException dbUpdateException)
        {
            var inner = GetInners(dbUpdateException).Last();
            string message = "";
            int i = 1;
            foreach (var entry in dbUpdateException.Entries)
            {
                var entry1 = entry;
                var obj = entry1.CurrentValues.ToObject();
                var type = obj.GetType();
                var propertyNames = entry1.CurrentValues.PropertyNames.Where(x => inner.Message.Contains(x)).ToList();
                // check MS SQL datetime2 error
                if (inner.Message.Contains("datetime2"))
                {
                    var propertyNames2 = from x in type.GetProperties()
                                            where x.PropertyType == typeof(DateTime) ||
                                                x.PropertyType == typeof(DateTime?)
                                            select x.Name;
                    propertyNames.AddRange(propertyNames2);
                }
    
                message += "Entry " + i++ + " " + type.Name + ": " + string.Join("; ", propertyNames.Select(x =>
                    string.Format("'{0}' = '{1}'", x, entry1.CurrentValues[x])));
            }
            return new Exception(message, dbUpdateException);
        }
    }
