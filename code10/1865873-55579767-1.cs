        public class FakeUpdateRequestExecutor : IFakeMessageExecutor
        {
            public bool CanExecute(OrganizationRequest request)
            {
                return request is UpdateRequest;
            }
            public OrganizationResponse Execute(OrganizationRequest request, XrmFakedContext ctx)
            {
                throw new InvalidPluginExecutionException("Throwing an Invalid Plugin Execution Exception for test purposes");
            }
            public Type GetResponsibleRequestType()
            {
                return typeof(UpdateRequest);
            }
        }
