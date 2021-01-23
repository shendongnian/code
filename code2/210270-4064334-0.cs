    public class BusinessManager<T> where T : Business, new() {
        private readonly T business;
        public BusinessManager() {
            business = new T();
        }
    }
