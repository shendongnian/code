    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Restaurant> RestaurantData = new List<Restaurant>();
                DataTable rptRestaurantInfo = new DataTable();
                rptRestaurantInfo.Columns.Add("Id", typeof(int));
                rptRestaurantInfo.Columns.Add("Name", typeof(string));
                rptRestaurantInfo.Columns.Add("Address", typeof(string));
                rptRestaurantInfo.Columns.Add("CategoryId", typeof(int));
                rptRestaurantInfo.Columns.Add("RestaurantId", typeof(int));
                rptRestaurantInfo.Columns.Add("CategoryName", typeof(string));
                foreach(Restaurant restaurant in RestaurantData)
                {
                    foreach(Category category in restaurant.RestaurantCategory)
                    {
                        rptRestaurantInfo.Rows.Add(new object[] {
                            restaurant.Id,
                            restaurant.Name,
                            restaurant.Address,
                            category.CategoryId,
                            category.RestaurantId,
                            category.CategoryName
                        });
                    
                    }
                }
            }
        }
        public class Restaurant
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Category> RestaurantCategory { get; set; }
            public string Address { get; set; }
        }
        public class Category
        {
            public int CategoryId { get; set; }
            public int RestaurantId { get; set; }
            public string CategoryName { get; set; }
        }
    }
