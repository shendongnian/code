    class Foo<T> {
        int input_as_int;
        float input_as_float;
        public void Set(string strval) {
            if (this.GetType().GetGenericArguments().First() == typeof(float)) {
                this.input_as_float = float.Parse(strval);
            } else if (this.GetType().GetGenericArguments().First() == typeof(int)) {
                this.input_as_int = int.Parse(strval);
            }
            // Else .. throw an exception? return default value? return 0? what makes sense to your application
        }
