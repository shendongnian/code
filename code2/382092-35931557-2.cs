    public class RequiredGuidAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var guid = CastToGuidOrDefault(value);
            return !Equals(guid, default(Guid));
        }
        private static Guid CastToGuidOrDefault(object value)
        {
            try
            {
                return (Guid) value;
            }
            catch (Exception e)
            {
                if (e is InvalidCastException || e is NullReferenceException) return default(Guid);
                throw;
            }
        }
    }
