    [AttributeUsage(AttributeTargets.All)]
    public class BugExpiryAttribute : System.Attribute
    {
        // don't tell 'anyone' about this hack attribute!!
        public BugExpiryAttribute(string bugAuthor, string expiryDate)
        {
            DateTime convertedDate = DateTime.Parse(expiryDate);
            Debug.Assert(DateTime.Now <= convertedDate, 
                string.Format("{0} promised to remove this by {1}", 
                    bugAuthor, convertedDate.ToString("dd-MMM-yyyy")));
        }
    }
