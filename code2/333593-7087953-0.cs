     [ServiceContract(CallbackContract = typeof(TestServiceCallback))]
        public interface TestService
        {
            [OperationContract(IsOneWay = false)]
            byte[] TestMethod(string testParam);
    }
