        private class CustomerGroupingKey
        {
            public CustomerGroupingKey(string country, string gender)
            {
                Country = country;
                Gender = gender;
            }
            public string Country { get; }
            public string Gender { get; }
        }
