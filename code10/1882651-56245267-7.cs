    private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
    {
        foreach (var person in Persons)
        {
            person.Name = EditName;
        }
    }
    private void TxtCity_TextChanged(object sender, TextChangedEventArgs e)
    {
        foreach (var person in Persons)
        {
            person.City = EditCity;
        }
    }
