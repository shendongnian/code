     int quantity = 1500;
     float price = 1.50F;
     float discount = 0.05F;
     Console.WriteLine(quantity.ToString("n0"));        // Outputs "1,500"
     Console.WriteLine(price.ToString("c"));            // Outputs "£1.50"
     Console.WriteLine(discount.ToString("p1"));        // Outputs "5.0 %"
