    public class ViewModelLocator 
    {
        private readonly ServiceProviderBase _sp;
        public ViewModelLocator()
        {
            _sp = ServiceProviderBase.Instance;
            // 1 VM for all places that use it. Just an option
            Book = new BookViewModel(_sp.PageConductor, _sp.BookDataService); 
        }
        public BookViewModel Book { get; set; }
        //get { return new BookViewModel(_sp.PageConductor, _sp.BookDataService); }
        // 1 new instance per View 
        public CheckoutViewModel Checkout
        {
            get { return new CheckoutViewModel(_sp.PageConductor, _sp.BookDataService); }
        }
    }
