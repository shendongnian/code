    using System;
    using System.Collections.Generic;
    public class C {
        public List<Object> mList;
    
        public void M() {
            this.mList?.Add(new object());
        }
    }
