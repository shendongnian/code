    public partial class User
    {
        public string Description
        {
            get
            {
                 return string.Format("{0} {1} - {2}", FirstName, LastName, UserCode);
            }
        }
    }
