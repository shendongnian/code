    class Employee
    {
        public decimal payePlusNssf;
        public decimal nhifRate;
        public decimal Sum
        {
            get { return payePlusNssf + nhifRate ;}
        }
    }
