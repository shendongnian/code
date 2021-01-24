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
## 2. My extensions for Repos
c#
   //using AutoMapper.EntityFrameworkCore;
   //using Microsoft.EntityFrameworkCore;
 
    public static class RepoExtensions
    {
        public static TModel InsertOrUpdate<TModel, TModelDto>(this IRepository repository, TModelDto modelDto) where TModel : BaseEntity where TModelDto :
     BaseEntityDTO
        {
            TModel model = repository.DbSet<TModel>().Persist().InsertOrUpdate(modelDto);
            repository.Save();
            return model;
        }
        public static async Task<TModel> InsertOrUpdateAsync<TModel, TModelDto>(this IRepository repository, TModelDto modelDto) where TModel : BaseEntity where TModelDto :
      BaseEntityDTO
        {
            TModel model = repository.DbSet<TModel>().Persist().InsertOrUpdate(modelDto);
            await repository.SaveAsync();
            return model;
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
