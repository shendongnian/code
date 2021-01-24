    private async Task LoadData()
    {
        await Task.Run(() =>
        {
            using (var context = new DataModel.BusinessData())
            {
                this.People = new ObservableCollection(context.People.Select(person => new PersonItem(person)).ToArray());
            }
        });
    }
