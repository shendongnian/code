    EntityCollection Recipients;
    Entity entity = (Entity) context.InputParameters["Target"];
     
    IOrganizationServiceFactory serviceFactory 
      = (IOrganizationServiceFactory)serviceProvider.GetService(
        typeof(IOrganizationServiceFactory)); 
    IOrganizationService service = serviceFactory
      .CreateOrganizationService(context.UserId); 
     
    Content = entity.GetAttributeValue<String>("subject"); 
    Recipients = entity.GetAttributeValue<EntityCollection>("to"); 
     
    for (int i = 0; i < Recipients.Entities.Count; i++)
    {
      ActivityParty ap = Recipients[i].ToEntity<ActivityParty>();
      String contactid = ap.PartyId.Id.ToString();
      Contact c = (Contact) service.Retrieve(
        Contact.EntityLogicalName,
        ap.PartyId.Id,
        new ColumnSet(new string[]{ "mobilephone" }));
      String mobilephone = c.MobilePhone;
      ...
    } 
