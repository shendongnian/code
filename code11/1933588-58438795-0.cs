        private object mutex = new object();
        public bool UseFeatureInternal {
          get {
             lock(mutex){
               //put all get code - including return statements - into this block
             }
          }
          set {
             lock(mutex){
               //put all set code here
             }
          }
        }
