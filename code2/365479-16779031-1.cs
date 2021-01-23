     container.Register(
        AllTypes
            .FromAssemblyNamed("v2.Tasks")
            .Pick()
            .WithService.FirstNonGenericCoreInterface("v2.Domain"));
