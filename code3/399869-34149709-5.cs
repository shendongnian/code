    IClientQueryService service = _ioc.Resolve<IClientQueryService>(); // Repository pattern 
    var q = service.GetClients(); // withManyNavigationIncludes
    var r = q.Where<Item>(
        i =>
		    i.Name != null
			&& i.Name != ""
			// lather rinse repeat, with many sub-objects navigated also
		).AsQueryable();
    var projectionModel = new ProjectionModelBuilder();
    var s = projectionModel.Project<ClientDTO, Client>(r).AsQueryable();
