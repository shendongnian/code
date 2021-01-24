    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class ProductDetails
    {
        public int id { get; set; }
        public string product_name { get; set; }
        public int product_category_id { get; set; }
    }
    
    class Category
    {
        public int id { get; set; }
        public string category { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            string productJson = @"[{'id': '1', 'product_name':'test', 'product_category_id': '1'},
                                    {'id': '2', 'product_name':'Dining Chair', 'product_category_id': '3'},
                                    {'id': '3', 'product_name':'Dining Chippsss', 'product_category_id': '3'}]";
    
            string categoryJson = @"[{ 'id':'1','category':'Chairs'},
                                    { 'id':'2','category':'Tables'},
                                    { 'id':'3','category':'Beds'}]";
    
            var categories = JsonConvert.DeserializeObject<List<Category>>(categoryJson);
            var products = JsonConvert.DeserializeObject<List<ProductDetails>>(productJson);
    
            // Finding tables category
            var query = (from x in products
                         where x.product_category_id == 3
                         select x);
    
            foreach (var product in query)
            {
                var category = categories.SingleOrDefault(x => x.id == product.product_category_id);
    
                Console.WriteLine("Product Name: " + product.product_name + 
                                  " - Product Category: " + category.category);
            }
        }
    }
    
