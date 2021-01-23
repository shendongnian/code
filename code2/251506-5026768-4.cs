    class Form2
    {
        public Person Person
        {
            get { return new Person() { Name = txtName.Text, PhoneNumber = txtPhone.Text, City = txtCity.Text }; }
        }
    }
