    [ServiceBehavior(AddressFilterMode=AddressFilterMode.Any)]
    [AspNetCompatibilityRequirements(RequirementsMode= AspNetCompatibilityRequirementsMode.Required)]
    public class Service : IService {
    HttpContext.Current.Items["_EntityContext"] = new DBEntities();
    ...
    }
