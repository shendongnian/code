c#
    //using AutoMapper;
    //using AutoMapper.Configuration;
    //using AutoMapper.EquivalencyExpression;
    //using AutoMapper.Extensions.ExpressionMapping;
    services.AddAutoMapper (assemblyes);
    MapperConfigurationExpression configExpression = new MapperConfigurationExpression ();
    configExpression.AddCollectionMappers ();
    configExpression.AddExpressionMapping ();
    configExpression.UseEntityFrameworkCoreModel <BaseDbContext> (services.BuildServiceProvider (). 
    CreateScope (). ServiceProvider);
    configExpression.AddMaps (assemblyes);
    Mapper.Initialize (configExpression);
    Mapper.Configuration.AssertConfigurationIsValid ();
## 2. My extensions for AutoMapper
c#
//using AutoMapper;
//using AutoMapper.EntityFrameworkCore;
    public static class MapperExtension
    {
      public static TModel MapForInsertOrUpdate<TModel, TModelDto>(this IMapper mapper, 
      DbSet<TModel> sourceSet, TModelDto modelDto) where TModel : BaseEntity where TModelDto : 
      BaseEntityDTO
       {
        return sourceSet.Persist().InsertOrUpdate(modelDto);
       }
    }
## 3. An example of updating an entity by an entity in a service
before
> ```cs
> public int Update(TModelDTO entityDto)
> {
>     var entity = Map.For(entityDto);
>     return Repository.Update(entity);
> }
