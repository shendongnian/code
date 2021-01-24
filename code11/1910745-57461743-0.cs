        [Obsolete("Don't use floats", error: true)]
        public static bool Equals(float a, float b) {
            throw new NotImplementedException();
        }
        [Obsolete("Don't use floats", error: true)]
        public static bool Equals(double a, float b) {
            throw new NotImplementedException();
        }
        [Obsolete("Don't use floats", error: true)]
        public static bool Equals(float a, double b) {
            throw new NotImplementedException();
        }
        public static bool Equals(double firstDouble, double secondDouble) {
            return Math.Abs(firstDouble - secondDouble) <= double.Epsilon;
        }
