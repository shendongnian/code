    public void Update(string ac, string pr, string propertyName, object Value) {
        try {
            vm.Product = _product.Get(ac, pr);
               
            vm.GetType().GetProperty(propertyName).SetValue(vm, value, null)
        }
    }
