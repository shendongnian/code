    // Call on new selection
    void CallChange(object sender, SelectionChangedEventArgs args)
    {
      _controller.ChangeType(args.AddedItems.OfType<string>().FirstOrDefault() ?? string.Empty);
    }
