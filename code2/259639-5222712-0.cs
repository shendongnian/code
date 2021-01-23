    [AttributeUsage(AttributeTargets.All)]
    public class BugExpiryAttribute : System.Attribute
    {
        // don't tell 'anyone' about this hack attribute!!
        public BugExpiryAttribute(string expiryDate)
        {
            DateTime convertedDate = DateTime.Parse(expiryDate);
            Debug.Assert(DateTime.Now < convertedDate);
        }
    }
