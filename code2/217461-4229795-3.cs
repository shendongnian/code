    public partial class Incident
    {
       public string IDs
        {
            get
            {
                return BuggItems.Aggregate((a,b) => a + "," + b);
            }
        }
    }
