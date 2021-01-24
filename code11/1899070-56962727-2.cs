        public IActionResult Index()
        {
            List<Product> products= new List<Product>() {
                new Product{ Id = 1, Name = "foo", Price = 8, Weight = 12},
                new Product{ Id = 2, Name = "foo", Price = 12, Weight = 18},
                new Product{ Id = 3, Name = "bar", Price = 3, Weight = 1},
                new Product{ Id = 4, Name = "bar", Price = 6, Weight = 2},
            };
            var result = _mapper.Map<List<ProductDto>>(products);
            return Ok(result);
        }
