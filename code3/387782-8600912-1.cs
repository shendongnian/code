    public partial class User
    {
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
