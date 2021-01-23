    class ObjAA {
        public static T ReturnA<T>() where T : A, new() {
            T oAA = new T();
            // fill the properties of A
            return oAA;
        }
    }
