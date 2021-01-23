    public class BusinessManager<T> where T : Business
    { 
        Business biz;
        public BusinessManager()
        {
            biz = new T();
        }
        public string ShowBusinessName()
        {
            return biz.GetBusinessName();
        }
    }
