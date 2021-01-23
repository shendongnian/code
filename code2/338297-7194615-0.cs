    public class MyReadonlyData : IMyReadonlyData {
        private MyData instance;
        public int Data {
            get {
                return instance.Data;
            }
        }
        public MyReadonlyData( MyData mydata ) {
            instance = mydata;
        }
    }
    // no access to original object or setters, period.
