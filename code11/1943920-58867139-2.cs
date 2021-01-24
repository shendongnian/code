    // List of cartons
    var cartons = new List<double>
    {
        0.12,
        0.09,
        0.05
    };
    // Amount of stuff that you want to put into cartons
    var stuff = 0.32;
    var distribution = new Dictionary<double, int>();
    // For this algorithm, I want to sort by descending first.
    cartons = cartons.OrderByDescending(x => x).ToList();
    foreach (var carton in cartons)
    {
        var count = 0;
        while (stuff >= 0)
        {
            if (stuff >= carton)
            {
                // If the amount of stuff bigger than the carton size, we use carton size, then update stuff
                count++;
                stuff = stuff - carton;
                distribution.CreateNewOrUpdateExisting(carton, 1);
            }
            else
            {
                // Otherwise, among remaining cartons we pick the ones that will have empty space if the remaining stuff is put in
                var partial = cartons.Where(x => x - stuff >= 0 && x != carton);
                // Then we see which of them will have the least amount of empty space and add it to the dictionary
                var min = partial.Min();
                distribution.CreateNewOrUpdateExisting(min, 1);
                stuff = stuff - min;
            }
        }
    }
