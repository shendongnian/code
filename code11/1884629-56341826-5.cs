    public class MyViewModel 
    {
        private readonly IBarcodeScanner _scanner;
        /// <summary>
        /// Initializes a new instance of the <see cref="MyViewModel"/> class.
        /// </summary>
        /// <param name="scanner">The scanner, dependency-injected</param>
        public MyViewModel(IBarcodeScanner scanner)
        {
            // all business logic for scanners, just like DB, should be in "service"
            // and not in the VM
            _scanner = scanner;
        }
