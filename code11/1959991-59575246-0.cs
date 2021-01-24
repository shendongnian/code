    string[] cars = { "Volvo", "BMW", "Volvo", "Mazda", "BMW", "BMW" };
    // Get indices of BMW 
    var indicesArray = cars.Select((car, index) => car == "BMW" ? index : -1).Where(i => i != -1).ToArray();
    // Display indices
    Label1.Text = indicesArray.ToList().ForEach(i => i.ToString());
