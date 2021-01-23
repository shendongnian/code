    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
     
        [Column("Gender")]
        public string GenderString
        {
            get { return Gender.ToString(); }
            private set { Gender = EnumExtensions.ParseEnum<Gender>(value); }
        }
     
        [NotMapped]
        public Gender Gender { get; set; }
    }
