    // An aggregate catalog that combines multiple catalogs
	var catalog = new AggregateCatalog();
	// Add the WinApplicationFramework assembly to the catalog
	catalog.Catalogs.Add(new AssemblyCatalog(typeof(ICustomService).Assembly));
	// Load module assemblies from files *.Presentation.dll and *.Applications.dll
	foreach (string moduleAssembly in GetCustomModuleAssemblies())
	{
		catalog.Catalogs.Add(new AssemblyCatalog(moduleAssembly));
	}
	var container = new CompositionContainer(catalog, CompositionOptions.DisableSilentRejection);
	var batch = new CompositionBatch();
	batch.AddExportedValue(container);
	container.Compose(batch);
	// Initialize all presentation services
	var presentationServices = container.GetExportedValues<IPresentationService>();
	foreach (var presentationService in presentationServices) { presentationService.Initialize(); }
	// Initialize and run all module controllers
	moduleControllers = container.GetExportedValues<IModuleController>();
	foreach (var moduleController in moduleControllers) { moduleController.Initialize(); }
	foreach (var moduleController in moduleControllers) { moduleController.Run(); }
