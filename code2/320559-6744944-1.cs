        internal Dictionary<string, List<double>> _readings = new Dictionary<string, List<double>>();
        public void Test ()
        {
            _readings.Add("alpha", new List<double>() { 17.42, 19.42 });
            // getting alpha values
            var alphaValues = from p in _readings where p.Key == "alpha" select p.Value;
            foreach (double d in alphaValues.First())
                Console.WriteLine(d);
        }
