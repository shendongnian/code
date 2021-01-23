    public class BusinessManager<T> where T : Business {
        private readonly T business;
        public BusinessManager(T business) {
            this.business = business;
        }
        public string GetBusinessName() { 
            return this.business.GetBusinessName();
        }
    }
