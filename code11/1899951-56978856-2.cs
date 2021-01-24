    private Person SelectedPerson
    {
        get {return ((ObjectView<Person>)this.SortableBindingSource.Current)?.Object; }
    }
    private void DisplayPersons (IEnumerable<Person> personsToDisplay)
    {
        this.SortableBindingSource.DataSource = personsToDisplay.ToList();
        this.SortableBindingSource.Refresh(); // this will update the DataGridView
    }
    private IEnumerable<Person> DisplayedPersons
    {
        get {return this.SortableBindingSource; }
        // BindingListview<T> implements IEnumerable<T>
    }
