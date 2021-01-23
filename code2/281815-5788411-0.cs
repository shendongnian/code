    public class MyValidator
    {
        private readonly OneAndOnlyChecksumGenerator checksumGenerator;
        public MyValidator(OneAndOnlyChecksumGenerator checksumGenerator)
        {
            this.checksumGenerator = checksumGenerator; 
        }
        // ...
    }
