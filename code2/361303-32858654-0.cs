    [Serializable]
    public class FormattedDbEntityValidationException : Exception
    {
        public FormattedDbEntityValidationException(DbEntityValidationException innerException) :
            base(null, innerException)
        {
        }
        public override string Message
        {
            get
            {
                var innerException = InnerException as DbEntityValidationException;
                if (innerException == null) return base.Message;
                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine();
                foreach (var eve in innerException.EntityValidationErrors)
                {
                    sb.AppendLine(string.Format("- Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().FullName, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        object value;
                        if (ve.PropertyName.Contains("."))
                        {
                            var propertyChain = ve.PropertyName.Split('.');
                            var complexProperty = eve.Entry.CurrentValues.GetValue<DbPropertyValues>(propertyChain.First());
                            value = GetComplexPropertyValue(complexProperty, propertyChain.Skip(1).ToArray());
                        }
                        else
                        {
                            value = eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName);
                        }
                        sb.AppendLine(string.Format("-- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            value,
                            ve.ErrorMessage));
                    }
                }
                sb.AppendLine();
                return sb.ToString();
            }
        }
        private static object GetComplexPropertyValue(DbPropertyValues propertyValues, string[] propertyChain)
        {
            var propertyName = propertyChain.First();
            return propertyChain.Count() == 1 
                ? propertyValues[propertyName] 
                : GetComplexPropertyValue((DbPropertyValues)propertyValues[propertyName], propertyChain.Skip(1).ToArray());
        }
    }
