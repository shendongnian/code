    public class ContractModelBinder : DefaultModelBinder
    {
        private readonly ISession _session;
        private readonly IAuthenticationService _authService;
        public ContractModelBinder(ISession session, IAuthenticationService authService)
        {
            _session = session;
            _authService = authService;
        }
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string contractId = null;
            int version = 0;
            var contractIdValue = bindingContext.ValueProvider.GetValue("contractId");
            var versionValue = bindingContext.ValueProvider.GetValue("version");
            if (versionValue != null)
            {
                version = int.Parse(versionValue.AttemptedValue);
            }
            if (contractIdValue != null)
            {
                contractId = contractIdValue.AttemptedValue;
            }
            var contract = _session.Single<Contract>(contractId);
            if (contract == null)
            {
                throw new HttpException(404, "Not found");
            }
            var user = _authService.LoggedUser();
            if (contract.CreatedBy == null || 
                !contract.CreatedBy.Id.HasValue || 
                contract.CreatedBy.Id.Value != user.Id
            )
            {
                throw new HttpException(401, "Unauthorized");
            }
            if (contract.Versions.Count < version)
            {
                throw new HttpException(404, "Not found");
            }
            return contract;
        }
    }
