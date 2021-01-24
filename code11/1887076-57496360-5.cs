    public class ProcessWhichCallsTheSecretMethod
    {
        private DIContainer _di;
        private ClassWithSecretMethod _secret;
    
        public ProcessWhichCallsTheSecretMethod(DIContainer di, ClassWithSecretMethod secret)
        {
            _di = di;
            _secret = secret;
        }
    
        public void TheProcessMethod()
        {
            Database database = _di.Factories.DatabaseFactory.getDatabase();
            _secret.SecretMethod(database);
        }
    }
