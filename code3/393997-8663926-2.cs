    public void Update(string ac, string pr, string propertyName, object Value) {
        try {
            vm.Product = _product.Get(ac, pr);
            vm.Product.GetType().GetProperty(propertyName).SetValue(vm.Product, value, null);
            _product.AddOrUpdate(vm.Product);
        }
    }
