    public class Something
    {
        private string someValue;
        public class Something(string someValue)
        {
            // must use "this" to access the member variable,
            // because a local variable has the same name
            this.someValue = someValue;
        }
    }
