    private void OnItemsSourceBindingChanged()
    {
        var newValue = this.EvaluateItemsSourceBinding();
        if (newValue != this.ItemsSource) //it will be equal, as its still the same list
        {
            this.AddNewItems();
        }
    }
