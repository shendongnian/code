        private void CreateNewDepartment()
        {
            if ((textBox1.Text != String.Empty) && (comboBox1.SelectedIndex >= 0))
            {
                ScansEntities1 db = new ScansEntities1();
                Person person = new Person() {Id = /*SomeId*/};
                db.AttachTo("Person", person);
                Department department = new Department()
                {
                    Name = textBox1.Text,
                    Person = person
                };
                db.AddToDepartment(department);
                db.SaveChanges();
            }
        }
