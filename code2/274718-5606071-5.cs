    public class ContractService : IContractService
    {
        private readonly ISession _session;
        private readonly IAuthenticationService _authService;
        // Use Dependency Injection for this!
        public ContractService(ISession session, IAuthenticationService authService)
        {
           _session = session;
           _authService = authService;
        }
        public Contract GetContract(int id)
        {
            var contract = _session.Single<Contract>(contractId);
            // hanlde somwhere else whether it's null or not
            return contract;
        }
        public ValidationResult ValidateContract(Contract contract)
        {
            var user = _authService.LoggedUser();
            if (contract.CreatedBy == null || !contract.CreatedBy.Id.HasValue ||
                contract.CreatedBy.Id.Value != user.Id) 
                  return ValidationResult.Unauthorized;
            if (contract.Versions.Count < version) 
                return ValidationResult.NotFound;
            return ValidationResult.Valid;
        }
    }
