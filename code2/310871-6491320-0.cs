    public class Customer
    {
      public string Name {get; set; }
            public int gender { get; set; }
            public enumGender Gender
            {
                get { return (CodeFirstEF.Gender) gender; }
                set { gender = (int) value; }
            }
    }
    
    public enum enumGender 
    {
        Male,
        Female
    }
