        public class RandomCodeActivity : CodeActivity
        {
            protected override void Execute(CodeActivityContext context)
            {
                var workflowContext = context.GetExtension<IWorkflowContext>();
                var serviceFactory = context.GetExtension<IOrganizationServiceFactory>();
                var service = serviceFactory.CreateOrganizationService(workflowContext.UserId);
                var accountToUpdate = new Account() { Id = new Guid("e7efd527-fd12-48d2-9eae-875a61316639"), Name = "A new faked name!" };
                service.Execute(new UpdateRequest { Target = accountToUpdate });
            }
        }
