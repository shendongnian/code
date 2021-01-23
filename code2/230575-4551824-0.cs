    private void mysList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Person p = (Person)myList.SelectedItem;
        appSettings["name"] = String.Format("{0}, {1}, {2}, {3}", p.Name, p.Age, p.Gender, p.Height);
    }
