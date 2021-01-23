    // I'm making up the types here; modify to match your actual types
    public interface IMyObject {
        public int Rate { get; set; }
        public DateTime Date { get; set; }
        public int MinVal { get; set; }
        public int MaxVal { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    public static class MyObjectFactory {
        public static T Create<T>(int rate, DateTime date, /* etc.. */) 
                where T : IMyObject, new() {
            if (/* tests */) {
                throw new MyObjectException("Constraint violated ...");
            }             
            T obj = new T();
            obj.Rate = rate;
            obj.Date = date;
            // etc ....
            return obj;
        }
    }
