        public  Product GetProd(Product product)
        {
            Product prod = new Product();
            prod = product; //this is a new object referencing the passed one.
            return prod; //returning prod is equals returning product in this scenario.
        }
