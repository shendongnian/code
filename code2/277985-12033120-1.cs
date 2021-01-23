    public class ContractUnbinder : IModelUnbinder<Contract>
    {
        public void UnbindModel(RouteValueDictionary routeValueDictionary, string routeName, Contract contract)
        {
            if (user != null)
                routeValueDictionary.Add("cityAlias", contract.Id);
        }
    }
