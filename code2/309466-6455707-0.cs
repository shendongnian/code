    public partial class Person
    {
        public string FullName
        {
           get { return String.Format("{0}, {1}", LastName, FirstName); }
        }
    
    }
