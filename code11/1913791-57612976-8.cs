        public POSViewModel()
        {   
            CartViewModel = new CartViewModel();    
            ProductsViewModel = new ProductsViewModel(CartViewModel);
        }
