        public static <T extends A<T>> T process(Class<T> clazz) 
        {
            T o = clazz.newInstance();
            process( o ); 
            return o;
        }
        X x = process(X.class); // not too verbose
