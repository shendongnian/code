    Scan(x =>
    {
        x.AssemblyContainingType<Harvester_Kubota_Rosemary>();
        x.AddAllTypesOf<ISpiceHarvester>()
         .NameBy(type => "I" + type.Name.Split('_').Last() + "Harvester");
