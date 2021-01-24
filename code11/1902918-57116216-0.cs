    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication120
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Item> items = new List<Item>() { 
                    new Item() { Id = 1, Color = "Red", Texture = "Rough",  Year = 2019},
                    new Item() { Id = 2, Color = "Green", Texture = "Soft",  Year = 2019},
                    new Item() { Id = 3, Color = "Blue", Texture = "Rough",  Year = 2019},
                    new Item() { Id = 4, Color = "Red", Texture = "Soft",  Year = 2018}
                };
                DataTable dt = new DataTable();
                dt.Columns.Add("Color", typeof(string));
                dt.Columns.Add("Texture", typeof(string));
                dt.Columns.Add("Year", typeof(int));
                foreach (Item item in items.Where(x => (x.Texture == "Rough") && (x.Year == 2019)))
                {
                    dt.Rows.Add(new object[] { item.Color, item.Texture, item.Year });
                }
     
            }
     
        }
        public class Item
        {
            public int Id { get; set; }
            public string Color { get; set; }
            public string Texture { get; set; }
            public int Year { get; set; }
        }
    }
