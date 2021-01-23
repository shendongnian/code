    private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            TextValue="Hello";
            PersonModel newPerson = new PersonModel();
            newPerson.Age = 12;
            newPerson.FirstName = "AA";
            newPerson.LastName = "BB";
            SelectedPerson = newPerson;
        }
