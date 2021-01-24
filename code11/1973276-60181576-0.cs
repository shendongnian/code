    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp2
    {
        class BuilderClass
        {
            List<BasketModel> baskets;
    
            public BuilderClass()
            {
                baskets = new List<BasketModel>() 
                { new BasketModel { FruitType = new string[] { "Apple", "Grapefruit", "Pineaple", "Bing Cherry", "Cantaloupe" } },
                  new BasketModel { FruitType = new string[] { "Grapefruit", "Cantaloupe", "Pineaple", "Boysenberries", "Apple" } },
                  new BasketModel { FruitType = new string[] { "Clementine", "Bing Cherry", "Boysenberries", "Cantaloupe", "Entawak" } },
                  new BasketModel { FruitType = new string[] { "Entawak", "Grapefruit", "Apple", "Pineaple", "Cantaloupe" } },
                  new BasketModel { FruitType = new string[] { "Apple", "Pineaple", "Bing Cherry", "Entawak", "Grapefruit" } }
                };
            }
    
            string[] BasketSearchedFruitTypes = new string[]
            { "Apple", "Grapefruit", "Pineaple" };
    
            public void check()
            {
                var qbaskets = baskets.AsQueryable();
                if (BasketSearchedFruitTypes != null && BasketSearchedFruitTypes.Length != 0)
                {
                    var result = qbaskets.Where(data => BasketSearchedFruitTypes.Any(x => data.FruitType.Contains(x))).ToList();
                    // result have list with count of 4
                }
            }
        }
    
        class BasketModel
        {
            public string[] FruitType { get; set; }
        }
    }
