    private async Task LoadData()
    {
        using (var context = new DataModel.BusinessData())
        {
            var people = await context.People.ToListAsync();
            this.People = await Task.Run(() => new ObservableCollection(people.Select(person => new PersonItem(person))));
        }
    }
