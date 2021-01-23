        using num = Double;
        static void Main(string[] args)
        {
            num[][] flight_data = new num[][] {
                new num[] { 0, 10, 20, 30 }, // time in seconds
                new num[] { 14500, 14750, 15000, 15125 }, //altitude in ft
                new num[] { 440, 425, 415, 410 }, // speed in knots
            };
            CubicSpline altitude = new CubicSpline(flight_data[0], flight_data[1]);
            CubicSpline speed = new CubicSpline(flight_data[0], flight_data[2]);
            num t = 22; //Find values at t
            num h = altitude.GetY(t);
            num v = speed.GetY(t);
            num ascent = altitude.GetYp(t); // ascent rate in ft/s
        }
