    class Foo {
        
        public delegate bool del(string foo);
    
        public Foo(del func) { //class constructor
                int i = 0;
                while(i != 10) {
                        func(i.ToString());
                        i++;
                }
        }
    }
