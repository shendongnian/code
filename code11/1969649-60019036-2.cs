    using System;
    public class C {
        public void M() {
            var x = 0;
            unsafe {
                for (var i = 0; i < 100; i++)
                {            
                    x+=i;
                }
            }
        }
    }
