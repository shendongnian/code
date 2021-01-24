    public abstract class BaseService {
        protected readonly IAmazonDynamoDB dynamoClient;
        protected readonly IPocoDynamo pocoDynamo;
    
        public BaseService(IAmazonDynamoDB dynamoClient, IPocoDynamo pocoDynamo) {        
            this.dynamoClient = dynamoClient;
            this.pocoDynamo = pocoDynamo;
        }
    }
