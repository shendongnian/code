                SqlCommand com = new SqlCommand("SELECT Name FROM [Responses_PersonalData]", con);
            con.Open();
            List<Person> listPeople = new List<Person>();
            Dictionary<string, Person> dicPeople = new Dictionary<string, Person>();
            using (con)
            {
                Random rand = new Random();
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Only use data where we have firstname, surname, approx 49,000 names in db.
                            string[] name = reader["Name"].ToString().Trim().Split(' ');
                            if (name.Length == 2)
                            {
                                Person person = new Person() { Age = rand.Next(0, 100), FirstName = name[0], LastName = name[1], Location = name[1] };
                                listPeople.Add(person);
                            }
                        }
                    }
                }
            }
            //Creates approx 100 million people exponentially.
            for (int i = 1; i < 12; i++)
                listPeople.AddRange(listPeople);
            //Group by firstname lastname tuple
            var tuppleDicPeople = listPeople
                .GroupBy(x => (x.FirstName, x.LastName))
                .ToDictionary(x => x.Key,
                    x => x.ToList());
            //Method 1
            List<Person> listPeopleCohortResults = listPeople.FindAll(p => p.FirstName == "Dean");
            //Method 2
            List<Person> dicPeopleCohortResults = tuppleDicPeople.Where(kvp => kvp.Key.FirstName == "Dean").SelectMany(kvp => kvp.Value).ToList();
