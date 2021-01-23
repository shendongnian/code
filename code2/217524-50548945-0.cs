    using System.Collections;
    using System.Collections.Generic;
    public class Actions {
        public Dictionary<string, System.Action> myActions = new Dictionary<string, System.Action>();
        public Actions() {
            myActions ["myKey"] = TheFunction;
        }
        public void TheFunction() {
            // your logic here
        }
    }
