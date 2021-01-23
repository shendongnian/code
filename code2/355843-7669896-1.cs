    const string entityName = "Name of internal name of the entity";
    const string systemName = "name of the external system";
    const string nameSpace = "name space of ect";
    
    BdcService bdcservice = SPFarm.Local.Services.GetValue<BdcService>();
    IMetadataCatalog catalog = bdcservice.GetDatabaseBackedMetadataCatalog(SPServiceContext.Current);
    ILobSystemInstance lobSystemInstance = catalog.GetLobSystem(systemName).GetLobSystemInstances()[systemName];
    IEntity entity = catalog.GetEntity(nameSpace, entityName);
    IFilterCollection filters = entity.GetDefaultFinderFilters();
    ComparisonFilter filter= (ComparisonFilter)filters[0];
    IEntityInstanceEnumerator enumerator = entity.FindFiltered(filters, lobSystemInstance);
    displayTable = entity.Catalog.Helper.CreateDataTable(enumerator);
