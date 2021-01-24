    private void UpdateLookupsOnViewModel(DummyViewModel vm)
    {
        if (vm is null)
        {
            throw new ArgumentNullException(nameof(vm));
        }
        vm.ProductLookup = GetProductFromCache("cache_product");
    }
