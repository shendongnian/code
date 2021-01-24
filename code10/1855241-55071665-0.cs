    public class Customer
    {
        private string name;
        private DateTime signUpDate;
        public DateTime BirthDate { get; }
        public int Age
        {
            get
            {
                int Age = (int)(DateTime.Today - BirthDate).TotalDays;
                Age = Age / 365;
                return Age;
            }
        }
        public Customer(string name, DateTime BirthDate, DateTime signUpDate)
        {
            this.name = name;
            this.signUpDate = signUpDate;
            this.BirthDate = BirthDate;
        }
    }
With a button to calculate the age and show:
        private void button1_Click(object sender, EventArgs e)
        {
            Customer test = new Customer("Lionel Messi", new DateTime(2000, 3, 12), new DateTime(2019, 2, 23));
            teAge.Text = test.Age.ToString();
        }
If you want to post exactly how you are accessing the age maybe I can help you more.
