     private static void ItemInput()
        {
             PricingInput(AskForTheItem());        
        }
    
        static Dictionary<String, int> AskForTheItem()
        {
    
                var result = new Dictionary<String, int>();
                Console.WriteLine("Add your items and price, once you're done, type empty item ");
                while (1)
                {
                    Console.Write("Add your item or keep empty :");
                    string item = Console.ReadLine();
                    if(String.IsNullOrEmpty(item)) return result;
                    Console.Write("Add the price:");
                    while(!int.TryParse(out var price, Console.ReadLine())                 Console.Write("Wrong price, please Add the price:");
                    result.Add(item, price);
                }
        }
    
        private static void PricingInput(Dictionary<String,int> list)
        {
            String minItem = null;
            int minPrice = -1;
            String maxItem = null;
            int maxPrice = -1;
            foreach(var i in list) {
                if(price<0 || i.Value<price) { minItem = i.Key; minPrice=i.Value;}
                if( i.Value>price) { maxItem = i.Key; maxPrice=i.Value;}
            Console.WriteLine($"The cheapest item is: {1} and the most expensive item is: {2} ",minItem,maxItem); }
