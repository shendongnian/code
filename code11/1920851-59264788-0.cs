    public static string GetClassDiscriminator<T>(this IEcoServiceProvider sp)
    {
        IEcoTypeSystem typeSys = sp.GetEcoService<ITypeSystemService>().TypeSystem;
        IClass cls = typeSys.AllClasses.Cast<IClass>().First(c => c.ObjectType == typeof(T));
        if (sp.GetEcoService<IExternalIdService>() is Eco.Services.Impl.ExternalIdServiceImpl_DbType)
        {
            ORMappingDefinition mapping = ((PersistenceMapperDb)DiamondsPMP.Instance.PersistenceMapper).EffectiveRunTimeMappingProvider.Mapping;
            if (mapping == null)
                throw new InvalidOperationException(PersistenceStringRes.MappingProviderNotInitialized);
            ClassDefinition classdef = mapping.Classes[typeSys.AllClasses[0].Name];
            if (classdef.Discriminators.Count == 0)
                throw new InvalidOperationException(PersistenceStringRes.RootclassHasNoDiscriminatorDefined);
            DiscriminatorDef discriminator = classdef.Discriminators.Cast<DiscriminatorDef>().First();
            DiscriminatorValue discvalue = discriminator.DiscriminatorValuesByClassId(cls.InternalIndex);
            if (discvalue == null)
                throw new InvalidOperationException(PersistenceStringRes.ClassHasNoDiscriminatorValueDefined);
            if (discvalue.IsFinal && cls.SubTypes.Count > 0)
                throw new InvalidOperationException(PersistenceStringRes.DiscriminatorIsFinal);
            return discvalue.Value;
        }
        else
            return cls.InternalIndex.ToString();
    }
