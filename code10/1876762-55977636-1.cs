    List<string> cars = null;
    foreach (string line in File.ReadLines(@"C:\Users\Me\cars.txt")) {
        if (!String.IsNullOrWhiteSpace(line)) {
            if (Int32.TryParse(line, out int year)) { // We have a year
                _years.Add(year);
                cars = new List<string>();
                _carsByYear.Add(year, cars);
            } else { // We have a car
                cars.Add(line);
            }
        }
    }
