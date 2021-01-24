    OnItemAdded(IItemModel addedItem)
    {
      var viewModel = new ItemViewModel(addedItem);
      this.Items.Add(viewModel);
    }
