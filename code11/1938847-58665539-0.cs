        private double data;
        public double[] ValidPropertyValues => new double[] { 1000, 2000, 4000 };
        public double Property
        {
            get { return data; }
            set {
                foreach (double val in ValidPropertyValues)
                if (value == val)
                {
                    data = value;
                    break;
                }
                //if not found, throw some exception
            }
        }
    }
