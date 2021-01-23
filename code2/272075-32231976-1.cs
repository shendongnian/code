            //Assume you're getting following values from search form.
            string userSuppliedProperty = "AverageRating";
            OperationType userSuppliedOperationType = OperationType.GreaterThan;
            var userSuppliedValue = 4.5;
            
            //Create DynamicSpecification from these properties and pass it to repository.  
            var userFilter = new DynamicSpecification<Product>(userSuppliedProperty, userSuppliedOperationType, userSuppliedValue);
            var filteredProducts = _repository.Get(userFilter);
            //You can also combine two specifications using either And or Or operation
            string userSuppliedProperty2 = "Category";
            OperationType userSuppliedOperationType2 = OperationType.EqualTo;
            var userSuppliedValue2 = "Keyboard";
            var userFilter2 = new DynamicSpecification<Product>(userSuppliedProperty2, userSuppliedOperationType2, userSuppliedValue2);
            
            var combinedFilter = userFilter.And(userFilter2);
            var filteredProducts2 = _repository.Get(combinedFilter);
            //and it support dynamic sorting
            string userSuppliedOrderingProperty = "Category";
            OrderType userSuppliedOrderType = OrderType.Ascending;
            var sortedFilteredProducts = _repository.Get(combinedFilter, o => o.InOrderOf(userSuppliedOrderingProperty, userSuppliedOrderType));
