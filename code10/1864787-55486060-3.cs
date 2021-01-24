    var outputPerDay = new OutputPerDay();
    outputPerDay[1].Add(new Pricing()); // Add a pricing to day 1
    outputPerDay[1].Add(new Pricing()); // Add another pricing to day 1
    outputPerDay[2].Add(new Pricing()); // Add a pricing to day 2
    Console.WriteLine(outputPerDay[1].Count); // Display how many pricings are in day 1.
