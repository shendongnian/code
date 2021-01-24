    public interface ICredentialProfileStoreChainWrapper
    {
        void TryGetAWSCredentials(/*TODO*/);
    }
    public class CredentialProfileStoreChainWrapper
    {
        readonly CredentialProfileStoreChain _Chain;
        public CredentialProfileStoreChainWrapper(CredentialProfileStoreChain chain)
        {
            _Chain = chain;
        }
        public void TryGetAWSCredentials(/*TODO*/)
        {
            _Chain.TryGetAWSCredentials(/*TODO*/);
        }
    }
    public class AWSDynamoDbManager : IAWSDynamoDbManager
    {
        public AWSDynamoDbManager(ICredentialProfileStoreChainWrapper chainWrapper, ILogger logger)
        {
            //TODO
            chainWrapper.TryGetAWSCredentials(/*TODO*/);
        }
    }
    public class Tests
    {
        [Test]
        public void TestToSeeIfWeCatchTheExceptionIfWeCannotConnectToTheDatabase()
        {
            var wrapper = new Mock<ICredentialProfileStoreChainWrapper>();
            var logger = new Mock<ILogger>();
            var manager = new AWSDynamoDbManager(wrapper.Object, logger.Object);
            wrapper.Setup(s => s.TryGetAWSCredentials(/*TODO*/)).Throws(new Exception());
            //TODO
        }
    }
