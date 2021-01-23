    public class Book
    {
        private string _a;
        private string _b;
        private string _c;
        private string _d;
        public Book(string A, string B, string C, string D)
        {
            _a = A;
            _b = B;
            _c = C;
            _d = D;
        }
        public void AddCopy(Copy copy)
        {
            // within this method you can access the private fields, but there is no
            // way to access the A, B, C and D parameters of the constructor.
        }
    }
