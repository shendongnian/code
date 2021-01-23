         container.Register(
            AllTypes
                .FromAssemblyNamed("v2.Tasks")
                .Pick().If(t => t.Name.EndsWith("Tasks"))
                .WithService.FirstNonGenericCoreInterface("v2.Domain"));
