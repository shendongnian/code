    class A<T> where T : class {
    
        public void DoWork<K>() where K : class, T {
    
            var b = new B<K>(); // <- compile time error
        }
    }
    
    class B<U> where U : class {
    
    }
