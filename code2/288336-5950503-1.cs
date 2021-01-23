    public class MySingleton {
        // object for synchronization
        private static readonly object syncRoot = new object();
        // the singleton instance
        private static MySingleton @default;
        
        public static MySingleton Default {
            get {
                // geting singleton instance without locking
                var result = @default;
                // if result is NOT null, no additional action is required
                if ( object.ReferenceEquals(result, null) ){
                    // lock the synchronization object
                    lock(syncRoot) {
                        // geting singleton instanc in lock - because
                        // the value of @default field could be changed
                        result = @default;
                        // checking for NULL
                        if ( object.ReferenceEquals(result, null) ) {
                            // if result is NULL, create new singleton instance
                            result = new MySingleton();
                            // set the default instance
                            @default = result;
                        }
                    }
                }
                // return singleton instance
                return result;
            }
        }
    }
