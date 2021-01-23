    public struct YourType {
        private readonly decimal cost, tax;
        public decimal Cost { get { return cost; } }
        public decimal Tax { get { return tax; } }
        public YourType(decimal cost, decimal tax) {
            this.cost = cost;
            this.tax = tax;
        }
    }
