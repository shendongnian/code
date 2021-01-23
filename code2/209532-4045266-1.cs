    private void LoadUsersToComboBox()
    {
        using (ScansEntities3 db = new ScansEntities3())
        {
            var people = db.People.ToList();
            
            foreach (var person in people)
                db.Detach(person);
        
            comboBox1.DataSource = people;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
        }
    }
