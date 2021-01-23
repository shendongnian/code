    comboProperty.Datasource = myEntityObject.GetType().GetProperties()
    comboOperation.Datasource = new List<Predicate>
        {
            {
                Name = "Contains",
                Predicate = (s1, s2) => s1 != null && s1.Contains(s2),
            },
            {
                Name = "Equals",
                Predicate = (s1, s2) => string.Compare(s1, s2) == 0,
            },
            //...
        }
