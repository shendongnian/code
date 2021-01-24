        private static int index = -1;
        private static double value = Double.MinValue;
        [TestMethod]
        public void MaxTest()
        {
            
            List<double> nums = new List<double> { 0.2, 5.0, 12.0 };
            var x = nums.Max(num => Transform(num));
        }
        public double Transform(double n)
        {
            var r = n - Math.Pow(n, 2);
            if (r > value)
            {
                value = r;
                index++;
            }
            return r;
        }
