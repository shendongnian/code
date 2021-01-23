    class MathCalculations
    {
        private Func<double, double, double> min = Math.Min;
        private Func<double, double, double> max = Math.Max;
        private Func<double, double> sin = Math.Sin;
        private Func<double, double> tanh = Math.Tanh;
        void DoCalculations()
        {
            var r = min(max(sin(3), sin(5)), tanh(40));
        }
    }
