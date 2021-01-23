    public class Age
    {
        private readonly DateTime dob;
        public Age(DateTime dob)
        {
            this.dob = dob;           
        }
        public int Value
        {
            get { return this.CalculateAge(this.dob); }
        }
        private int CalculateAge(DateTime dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (today.Month < dob.Month || (today.Month == dob.Month && today.Day < dob.Day))
                age--;
            return age;
        }
    }
